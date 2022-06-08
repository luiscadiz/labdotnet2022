using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TP4.Entities;


namespace App.TP4.Logic
{
    public class EmployeesLogic : BaseLogic, IABMLogic<Employees>
    {
        public List<Employees> GetAll()
        {
            return _context.Employees.ToList();
        }

        public void Insert(Employees employee)
        {
            //Genera un nuevo ID a partir del ultimo encontrado
            employee.EmployeeID = GetLastID() + 1;
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Employees employeeFind = _context.Employees.First(e => e.EmployeeID == id);
            _context.Employees.Remove(employeeFind);
            _context.SaveChanges();
        }

        public void Update(Employees employee, int id)
        {
            var employeeUpdate = _context.Employees.First(e => e.EmployeeID == id);
            employeeUpdate.Title = employee.Title;
            employeeUpdate.Address = employee.Address;
            _context.SaveChanges();
        }

        private int GetLastID()
        {
            return _context.Employees.Max(x => x.EmployeeID);
        }
    }
}
