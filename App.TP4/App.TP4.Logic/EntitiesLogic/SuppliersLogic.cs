using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TP4.Entities;

namespace App.TP4.Logic
{
    public class SuppliersLogic : BaseLogic, IABMLogic<Suppliers>
    {
        public List<Suppliers> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public void Insert(Suppliers newSupplier)
        {
            //Genera un nuevo ID a partir del ultimo encontrado
            newSupplier.SupplierID= GetLastID() + 1;
            _context.Suppliers.Add(newSupplier);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var products = _context.Products.Where(o => o.SupplierID == id);
            foreach (var product in products)
            {
                product.SupplierID = null;
            }
            var supplierFind = _context.Suppliers.First(s => s.SupplierID == id);
            _context.Suppliers.Remove(supplierFind);
            _context.SaveChanges();
        }

        public void Update(Suppliers newSupplier, int id)
        {
            try
            {
                var supplierUpdate = _context.Suppliers.First(e => e.SupplierID == id);
                supplierUpdate.Address = newSupplier.Address;
                supplierUpdate.Phone = newSupplier.Phone;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new IdErrorExeption();
            }
           
            
        }

        private int GetLastID()
        {
            return _context.Employees.Max(x => x.EmployeeID);
        }
    }
}
