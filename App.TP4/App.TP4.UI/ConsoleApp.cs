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
            EmployeesLogic employeesLogic = new EmployeesLogic();
            CustomersLogic customersLogic = new CustomersLogic();
            switch (optionCurrent)
            {
                case 0:
                    OptionOneGetInformation(employeesLogic,customersLogic);
                    break;
                case 1:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionTwoInsertEmployee(employeesLogic);
                    break;
                case 2:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionDelete(employeesLogic);
                    break;
                case 3:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionUpdate(employeesLogic);
                    break;
                default:
                    break;
            }
        }
        private static void OptionOneGetInformation(EmployeesLogic employeesLogic, CustomersLogic customersLogic)
        {
            Menu menuEntities = new Menu(Headers.HeaderOptionOne, Options.OptionsOne);
            menuEntities.RunMenu();
            switch (menuEntities.SelectedIndex)
            {
                case 0:
                    Console.WriteLine(Headers.HeaderOptions);
                    ShowTableEmployee(employeesLogic);
                    Console.WriteLine("Presione Enter para volver al menu!..");
                    Console.ReadLine();
                    break;
                case 1:
                    Console.WriteLine(Headers.HeaderOptions);
                    customersLogic.ShowAll();
                    Console.WriteLine("Presione Enter para volver al menu!..");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        private static void ShowTableEmployee(EmployeesLogic employeeLogic)
        {
            bool estado = true;
            Console.WriteLine("****RECUPERANDO DATOS - ESPERE POR FAVOR!*****");
            foreach (Employees employee in employeeLogic.GetAll())
            {
                if (estado)
                {
                    TableGraphic.PrintRow("ID", "NOMBRE", "APELLIDO", 
                                          "PUESTO", "F. NACIMIENTO",
                                          "CIUDAD", "DIRECCIÓN", "PAIS");
                    TableGraphic.PrintLine();
                    estado = false;
                }
                TableGraphic.PrintRow(employee.EmployeeID.ToString(), employee.FirstName,
                                employee.LastName, employee.Title, employee.BirthDate.ToString(),
                                employee.City, employee.Address, employee.Country);
            }
            Console.WriteLine("");
        }

        private static void OptionTwoInsertEmployee(EmployeesLogic employeesLogic)
        {
            try
            {
                Console.Write("Ingresar Nombre:_ ");
                string firtName = Console.ReadLine();
                Console.Write("Ingresar Apellido:_ ");
                string lastName = Console.ReadLine();
                Console.Write("Ingresar nombre del Puesto:_ ");
                string title = Console.ReadLine();
                Console.Write("Ingresar Dirección:_ ");
                string address = Console.ReadLine();
                employeesLogic.Insert(new Employees()
                {
                    FirstName = firtName,
                    LastName = lastName,
                    Title = title,
                    Address = address
                });
                ShowTableEmployee(employeesLogic);
                Console.WriteLine("Presione Enter para volver al menu!..");
                Console.ReadLine();
            }
            catch(Exception)
            {
                Console.WriteLine("Se ingreso algun dato de forma incorrecta!");
            }
         
        }

        private static void OptionDelete(EmployeesLogic employeesLogic)
        {
            NewMethod(employeesLogic);
        }

        private static void NewMethod(EmployeesLogic employeesLogic)
        {
            //try
            //{
                ShowTableEmployee(employeesLogic);
                Console.Write("Ingrese el ID del empleado a eliminar:_");
                int entryID = Convert.ToInt32(Console.ReadLine());
                employeesLogic.Delete(entryID);
                Console.WriteLine("****ELIMINACIÓN EXITOSA*****");
                ShowTableEmployee(employeesLogic);
                Console.ReadLine();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine("INGRESO DE DATO NO VALIDO!!!");
            //    Console.ReadLine();
            //}
        }

        private static void OptionUpdate(EmployeesLogic employeesLogic)
        {
            try
            {
                ShowTableEmployee(employeesLogic);
                Console.Write("Ingrese el ID del empleado a Actualizar:_ ");
                int entryID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingrese nuevo Puesto:_ ");
                string newTitle = Console.ReadLine();
                Console.Write("Ingrese nuevo Dirección:_ ");
                string newAddress = Console.ReadLine();
                employeesLogic.Update(new Employees()
                {
                    Title = newTitle,
                    Address = newAddress
                }, entryID);
                ShowTableEmployee(employeesLogic);
                Console.ReadLine();
            }catch(Exception)
            {
                Console.WriteLine("Ocurrio un problema en la actualización");
                Console.ReadLine();
            }
          
        }
    }
}
