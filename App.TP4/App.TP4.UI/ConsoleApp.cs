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
            SuppliersLogic suppliersLogic = new SuppliersLogic();
            switch (optionCurrent)
            {
                case 0:
                    OptionOneGetInformation(employeesLogic, suppliersLogic);
                    break;
                case 1:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionTwoInsertSupplier(suppliersLogic);
                    break;
                case 2:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionTreeDeleteSupplier(suppliersLogic);
                    break;
                case 3:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionFourUpdateSupplier(suppliersLogic);
                    break;
                default:
                    break;
            }
        }
        private static void OptionOneGetInformation(EmployeesLogic employeesLogic, SuppliersLogic suppliersLogic)
        {
            Menu menuEntities = new Menu(Headers.HeaderOptionOne, Options.OptionsOne);
            menuEntities.RunMenu();
            switch (menuEntities.SelectedIndex)
            {
                case 0:
                    Console.WriteLine(Headers.HeaderOptions);
                    ShowTableSuppliers(suppliersLogic);
                    Console.WriteLine("Presione Enter para volver al menu!..");
                    Console.ReadLine();
                    break;
                case 1:
                    Console.WriteLine(Headers.HeaderOptions);
                    ShowTableEmployee(employeesLogic);
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
                    TableGraphic.PrintLine();
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
            TableGraphic.PrintLine();
            Console.WriteLine("");
        }

        private static void ShowTableSuppliers(SuppliersLogic suppliersLogic)
        {
            bool estado = true;
            Console.WriteLine("****RECUPERANDO DATOS - ESPERE POR FAVOR!*****");
            foreach (Suppliers supplier in suppliersLogic.GetAll())
            {
                if (estado)
                {
                    TableGraphic.PrintLine();
                    TableGraphic.PrintRow("ID", "EMPRESA","DIRECCIÓN", "TELEFONO", "CIUDAD");
                    TableGraphic.PrintLine();
                    estado = false;
                }
                TableGraphic.PrintRow(supplier.SupplierID.ToString(), supplier.CompanyName, 
                                      supplier.Address, supplier.Phone, supplier.City);
            }
            TableGraphic.PrintLine();
            Console.WriteLine("");
        }

        private static void OptionTwoInsertSupplier(SuppliersLogic suppliersLogic)
        {
            try
            {
                Console.Write("Ingresar Nombre del Proveedor:_ ");
                string nameCompany = Console.ReadLine();
                Console.Write("Ingresar Dirección del Proveedor:_ ");
                string addtressCompany = Console.ReadLine();
                Console.Write("Ingresar numero de telefono:_ ");
                string nroCompany = Console.ReadLine();
                Console.Write("Ingresar ciudad del Proveedor:_ ");
                string cityCompany = Console.ReadLine();
                suppliersLogic.Insert(new Suppliers()
                {
                    CompanyName = nameCompany,
                    Address = addtressCompany,
                    Phone = nroCompany,
                    City = cityCompany
                });
                ShowTableSuppliers(suppliersLogic);
                Console.WriteLine("Presione Enter para volver al menu!..");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Se ingreso algun dato de forma incorrecta!");
            }

        }

        private static void OptionTreeDeleteSupplier(SuppliersLogic suppliersLogic)
        {

            try
            {
                ShowTableSuppliers(suppliersLogic);
                Console.Write("*==>Ingrese el ID del Proveedor a eliminar:_");
                int entryID = Convert.ToInt32(Console.ReadLine());
                suppliersLogic.Delete(entryID);
                Console.WriteLine("****ELIMINACIÓN EXITOSA*****");
                ShowTableSuppliers(suppliersLogic);
                Console.ReadLine();
            }catch (Exception ex){

                Console.WriteLine(ex.Message);
                Console.WriteLine("*==> INGRESO DE DATO NO VALIDO!!!");
                Console.ReadLine();
            }
        }

        private static void OptionFourUpdateSupplier(SuppliersLogic suppliersLogic)
        {
            try
            {
                int entryID;
                ShowTableSuppliers(suppliersLogic);
                Console.Write("*==> Ingrese el ID del proveedor a Actualizar:_ ");
                bool entryTrue = int.TryParse(Console.ReadLine(), out entryID);
                if (!entryTrue) throw new IdErrorExeption(); 
                Console.Write("Ingrese nuevo Dirección:_ ");
                string newAddress = Console.ReadLine();
                Console.Write("Ingrese nuevo Numero de Telefono:_ ");
                string newPhone = Console.ReadLine();
                suppliersLogic.Update(new Suppliers()
                {
                    Address = newAddress,
                    Phone = newPhone
                }, entryID);
                ShowTableSuppliers(suppliersLogic);
                Console.ReadLine();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
          
        }
    }
}
