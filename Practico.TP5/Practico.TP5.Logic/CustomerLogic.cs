using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practico.TP5.Datos;
using Practico.TP5.Entities;

namespace Practico.TP5.Logic
{
    public class CustomerLogic: BaseLogic
    {
        #region Exercise 1
        public List<Customers> GetAllCustomers()
        {
            var queryGetAllCustomer = from customer in _context.Customers
                                      select customer;
            return queryGetAllCustomer.ToList();
        }
        #endregion

        #region Exercise 4
        public List<Customers> GetCustomerRegionWA()
        {
            var queryGetCustomerRegionWA = _context.Customers.Where(c => c.Region == "WA");
            return queryGetCustomerRegionWA.ToList();
        }
        #endregion

        #region Exercise 6
        public List<CustomerName> GetNamesCustomers()
        {
            var queryGetNamesCustomers = _context.Customers.Select(c => new CustomerName
            {
                NameUpper = c.ContactName.ToUpper(),
                NameLower = c.ContactName.ToLower()
            });
            return queryGetNamesCustomers.ToList();
        }
        #endregion

        #region Exercise 7
        public List<CustomerOrder> GetCustomersJoinOrders()
        {
            var queryGetCustomersJoinOrders = from customers in _context.Customers
                                              join orders in _context.Orders
                                              on customers.CustomerID
                                              equals orders.CustomerID
                                              where customers.Region == "WA" 
                                              && orders.OrderDate > new DateTime(1997, 1, 1)
                                              select new CustomerOrder
                                              {
                                                 Customer = customers,
                                                 Order = orders
                                              };

            return queryGetCustomersJoinOrders.ToList();
        }
        #endregion

        #region Exercise 8
        public List<Customers> GetFirstThreeCustomersWithRegionWA()
        {
            return _context.Customers.Where(c => c.Region == "WA").Take(3).ToList();
        }
        #endregion

        #region Exercise 13

        #endregion
    }
}
