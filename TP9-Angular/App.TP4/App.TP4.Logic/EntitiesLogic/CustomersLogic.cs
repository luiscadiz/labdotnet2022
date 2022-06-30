using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TP4.Data;
using App.TP4.Entities;

namespace App.TP4.Logic
{
    public class CustomersLogic : BaseLogic, IABMLogic<Customers>
    {
        public List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void ShowAll()
        {

            bool estado = true;
            Console.WriteLine("****RECUPERANDO DATOS - ESPERE POR FAVOR!*****");
            foreach (Customers customer in this.GetAll())
            {
                if (estado)
                {
                    TableGraphic.PrintRow("ID", "EMPRESA", "NOMBRE", "CARGO", "DIRECCIÓN",
                                    "CIUDAD", "PAIS");
                    TableGraphic.PrintLine();
                    estado = false;
                }
                TableGraphic.PrintRow(customer.CustomerID,
                             customer.CompanyName, customer.ContactName,
                             customer.ContactTitle,customer.Address,
                             customer.City,customer.Country);
            }
        }

        public void Insert(Customers customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var customerFound = _context.Customers.Find(id);
            _context.Customers.Remove(customerFound);
            _context.SaveChanges();
        }

        public void Update(Customers entities, int id)
        {
            throw new NotImplementedException();
        }
    }
}
