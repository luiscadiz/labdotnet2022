using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practico.TP5.Datos;
using Practico.TP5.Entities;

namespace Practico.TP5.Logic
{
    public class CustomerLogic
    {
        private readonly NorthwindContext _context;

        public CustomerLogic()
        {
            _context = new NorthwindContext();
        }
        public List<Customers> GetAll()
        {
            IQueryable<Customers> queryGetAllCustomer = from customer in _context.Customers
                                                        select customer;
            return queryGetAllCustomer.ToList();
        }

    }
}
