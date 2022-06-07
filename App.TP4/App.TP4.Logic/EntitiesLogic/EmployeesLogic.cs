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

        public void ShowAll()
        {
            var table = new TablePrinter("ID", "Nombre","Apellido");
            Console.WriteLine("****RECUPERANDO DATOS - ESPERE POR FAVOR!*****");
            foreach (Employees employee in this.GetAll())
            {
                //Console.WriteLine($"{customer.ContactName} - {customer.Address}");
                table.AddRow(employee.EmployeeID, employee.FirstName, employee.LastName);
            }
            table.Print();
        }

        public void Insert(Employees employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employeeFind = _context.Employees.Find(id);
            _context.Employees.Remove(employeeFind);
            _context.SaveChanges();
        }

        public void Update(Employees entities)
        {
            throw new NotImplementedException();
        }

        public int GetLastID()
        {
            return _context.Employees.Max(x => x.EmployeeID);
        }
    }
}
