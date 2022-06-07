using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TP4.Data;
using App.TP4.Entities;

namespace App.TP4.Logic
{
    public class CustomersLogic : BaseLogic
    {
        private IEnumerable<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void ShowAll()
        {
            var table = new TablePrinter("ID", "Nombre de contacto", "Dirección");
            Console.WriteLine("****RECUPERANDO DATOS - ESPERE POR FAVOR!*****");
            foreach (Customers customer in this.GetAll())
            {
                //Console.WriteLine($"{customer.ContactName} - {customer.Address}");
                table.AddRow(customer.CustomerID, customer.ContactName, customer.Address);
            }
            table.Print();
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

    }
}
