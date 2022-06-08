using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.TP4.Entities;
using App.TP4.Logic;

namespace App.TP4.UI
{
    public class ConsoleApp
    {
        public static void Start()
        {
            short optionCurrent;
            var headerHome = Headers.HeaderHome;
            var options = Options.OptionHome;
            Menu mainMenu = new Menu(headerHome, options);
            do
            {
                mainMenu.RunMenu();
                optionCurrent = mainMenu.SelectedIndex;
                SelectOption(optionCurrent);
            } while (optionCurrent >= 0 && optionCurrent <= options.Length - 2);
        }

        private static void SelectOption(int optionCurrent)
        {
            switch (optionCurrent)
            {
                case 0:
                    OptionOne();
                    break;
                case 1:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionInsertEmployee();
                    break;
                case 2:
                    OptionDelete();
                    break;
                case 3:
                    OptionUpdate();
                    break;
                default:
                    break;
            }
        }
        private static void OptionOne()
        {
            Menu menuEntities = new Menu(Headers.HeaderOptionOne, Options.OptionsOne);
            menuEntities.RunMenu();
            switch (menuEntities.SelectedIndex)
            {
                case 0:
                    Console.WriteLine(Headers.HeaderOptions);
                    CustomersLogic customersLogic = new CustomersLogic();
                    customersLogic.ShowAll();
                    Console.ReadLine();
                    break;
                case 1:
                    Console.WriteLine(Headers.HeaderOptions);
                    EmployeesLogic employeesLogic = new EmployeesLogic();
                    employeesLogic.ShowAll();
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        private static void OptionInsertEmployee()
        {
            EmployeesLogic employeesLogic = new EmployeesLogic();
            Employees employee= new Employees();
            Console.Write("Ingresar Nombre: _");
            employee.FirstName= Console.ReadLine();
            Console.Write("Ingresar Apellido: _");
            employee.LastName= Console.ReadLine();
            employeesLogic.Insert(employee); 
        }

        private static void OptionDelete()
        {
            EmployeesLogic employeesLogic = new EmployeesLogic();
            Console.WriteLine("Ingrese el ID del empleado");
            int employeID;
            bool entryID = int.TryParse(Console.ReadLine(), out employeID);
            if (entryID) employeesLogic.Delete(employeID);
            else Console.WriteLine("Ingreso de dato no valido");
        }

        private static void OptionUpdate()
        {

        }
    }
}
