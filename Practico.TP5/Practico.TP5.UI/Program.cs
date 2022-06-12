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

            var allCustormers = customerLogic.GetAll();

            foreach(var customer in allCustormers)
            {
                Console.WriteLine($"{customer.CompanyName} - {customer.ContactName}");
            }

            Console.ReadLine();
            

        }
    }
}
