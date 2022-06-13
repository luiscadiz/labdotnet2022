using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practico.TP5.Entities;
using Practico.TP5.Logic;

namespace Practico.TP5.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customerLogic = new CustomerLogic();
            var productLogic = new ProductsLogic();

            //foreach (var customer in customerLogic.GetAll())
            //{
            //    Console.WriteLine($"{customer.CompanyName} - {customer.ContactName}");
            //}

            foreach (var customerOrder in customerLogic.GetCustomersJoinOrders())
            {
                Console.WriteLine($"{customerOrder.Customer.Region} - {customerOrder.Order.OrderDate}");
            }

            Console.ReadLine();


        }
    }
}
