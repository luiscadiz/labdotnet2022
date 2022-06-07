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
        public List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}
