using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TP4.Entities;
using App.TP4.Logic;

namespace App.TP4.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomersLogic customersLogic = new CustomersLogic();

            foreach(Customers customer in customersLogic.GetAll())
            {
                Console.WriteLine($"{customer.ContactName} - {customer.Address}");
            }

            Console.ReadLine();
        }
    }
}
