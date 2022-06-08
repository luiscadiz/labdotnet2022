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
            bool estado = true;
            Console.WriteLine("****RECUPERANDO DATOS - ESPERE POR FAVOR!*****");
            foreach (Employees employee in this.GetAll())
            {
                if (estado)
                {
                    TablePinter.PrintRow("ID", "NOMBRE", "APELLIDO", "PUESTO", "CUMPLEAÑOS",
                                    "CIUDAD","DIRECCIÓN","PAIS");
                    TablePinter.PrintLine();
                    estado = false;
                }
                TablePinter.PrintRow(employee.EmployeeID.ToString(), employee.FirstName, 
                                employee.LastName, employee.Title, employee.BirthDate.ToString(), 
                                employee.City,employee.Address,employee.Country);
            }
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
            var employeeFind = _context.Employees.Find(id);
            _context.Employees.Remove(employeeFind);
            _context.SaveChanges();
        }

        public void Update(Employees entities)
        {
            throw new NotImplementedException();
        }

        private int GetLastID()
        {
            return _context.Employees.Max(x => x.EmployeeID);
        }
    }
}
