using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practico.TP5.Logic;
using Practico.TP5.Entities;

namespace Practico.TP5.UI
{
    public class PresentationTP5
    {
        ProductsLogic productLogic = new ProductsLogic();
        CustomerLogic customerLogic = new CustomerLogic();

        public void Start()
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

        private void SelectOption(int optionCurrent)
        {
            switch (optionCurrent)
            {
                case 0:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionOne();
                    break;
                case 1:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionTwo();
                    break;
                case 2:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionThree();
                    break;
                case 3:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionFour();
                    break;
                case 4:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionFive();
                    break;
                case 5:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionSix();
                    break;
                case 6:
                    Console.WriteLine(Headers.HeaderOptions);
                    OptionSeven();
                    break;
                default:
                    break;
            }
        }

        #region Option 1
        private void OptionOne()
        {
            
            Console.WriteLine("1. Query para devolver objeto customer.");
            ShowTableCustomer();
            
        }

        #endregion 

        #region Option 2

        private void OptionTwo()
        {
            bool estado = true;
            Console.WriteLine("2. Query para devolver todos los productos sin stock.");
            Console.WriteLine("");
            Console.WriteLine("****RECUPERANDO DATOS - ESPERE POR FAVOR!*****");
            foreach (var product in productLogic.GetProductsWithoutStock())
            {
                if (estado)
                {
                    TableGraphic.PrintLine();
                    TableGraphic.PrintRow("ID", "NOMRBE", "STOCK",
                                          "PRECIO");
                    TableGraphic.PrintLine();
                    estado = false;
                }
                TableGraphic.PrintRow(product.ProductID.ToString(), product.ProductName,
                                      product.UnitsInStock.ToString(), product.UnitPrice.ToString());
            }
            TableGraphic.PrintLine();
            Console.WriteLine("");
            Console.WriteLine("Presione Enter para volver al menu..");
            Console.ReadLine();
        }
        #endregion

        #region Option 3

        private void OptionThree()
        {
            bool estado = true;
            Console.WriteLine("3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
            Console.WriteLine("");
            Console.WriteLine("****RECUPERANDO DATOS - ESPERE POR FAVOR!*****");
            var products = productLogic.GetProductsWithMoreThanTreeUnits();
            foreach (var product in products)
            {
                if (estado)
                {
                    TableGraphic.PrintLine();
                    TableGraphic.PrintRow("ID", "NOMRBE", "STOCK",
                                          "PRECIO");
                    TableGraphic.PrintLine();
                    estado = false;
                }
                TableGraphic.PrintRow(product.ProductID.ToString(), product.ProductName,
                                      product.UnitsInStock.ToString(), product.UnitPrice.ToString());
            }
            TableGraphic.PrintLine();
            Console.WriteLine("");
            Console.WriteLine("Presione Enter para volver al menu..");
            Console.ReadLine();
        }

        #endregion

        #region Option 4
        private void OptionFour()
        {
            Console.WriteLine("4. Query para devolver todos los customers de la Región WA.");
            bool estado = true;
            Console.WriteLine("");
            Console.WriteLine("****RECUPERANDO DATOS - ESPERE POR FAVOR!*****");
            foreach (var customer in customerLogic.GetCustomerRegionWA())
            {
                if (estado)
                {
                    TableGraphic.PrintLine();
                    TableGraphic.PrintRow("ID", "COMPAÑIA", "DIRECCIÓN",
                                          "CIUDAD", "REGION");
                    TableGraphic.PrintLine();
                    estado = false;
                }
                TableGraphic.PrintRow(customer.CustomerID.ToString(), customer.CompanyName,
                                      customer.Address, customer.City, customer.Region);
            }
            TableGraphic.PrintLine();
            Console.WriteLine("");
            Console.WriteLine("Presione Enter para volver al menu..");
            Console.ReadLine();
        }
        #endregion

        #region Option 5
        private void OptionFive()
        {
            try
            {
                Console.WriteLine("5. Query para devolver el primer elemento o nulo de una lista de productos" + 
                                  " donde el ID de producto sea igual a 789");
                Products product = productLogic.GetFirstElement();
                Console.WriteLine($"{product.ProductID} - {product.ProductName}");
            }
            catch(Exception )
            {
                Console.WriteLine("Elemento Nulo");
            }
            finally
            {
                Console.ReadLine();
            }
        }
        #endregion

        #region Option 6
        private void OptionSix()
        {
            bool estado = true;
            Console.WriteLine("6. Query para devolver los nombre de los Customers." + 
                               "Mostrarlos en Mayuscula y en Minuscula.");
            Console.WriteLine("");
            Console.WriteLine("****RECUPERANDO DATOS - ESPERE POR FAVOR!*****");
            var customersNames = customerLogic.GetNamesCustomers();
            foreach (var customerName in customersNames)
            {
                if (estado)
                {
                    TableGraphic.PrintLine();
                    TableGraphic.PrintRow("NOMBRE", "Nombre");
                    TableGraphic.PrintLine();
                    estado = false;
                }
                TableGraphic.PrintRow(customerName.NameUpper, customerName.NameLower);
            }
            TableGraphic.PrintLine();
            Console.WriteLine("");
            Console.WriteLine("Presione Enter para volver al menu..");
            Console.ReadLine();
        }
        #endregion

        #region Option 7
        private void OptionSeven()
        {
            bool estado = true;
            Console.WriteLine("7. Query para devolver Join entre Customers y Orders donde los customers sean de la" + 
                              "Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.");
            Console.WriteLine("");
            Console.WriteLine("****RECUPERANDO DATOS - ESPERE POR FAVOR!*****");
            foreach (var customerOrder in customerLogic.GetCustomersJoinOrders())
            {
                if (estado)
                {
                    TableGraphic.PrintLine();
                    TableGraphic.PrintRow("ID", "COMPAÑIA", "REGION",
                                          "FECHA ORDEN");
                    TableGraphic.PrintLine();
                    estado = false;
                }
                TableGraphic.PrintRow(customerOrder.Customer.CustomerID, customerOrder.Customer.CompanyName,
                                       customerOrder.Customer.Region, customerOrder.Order.OrderDate.ToString());
            }
            TableGraphic.PrintLine();
            Console.WriteLine("");
            Console.WriteLine("Presione Enter para volver al menu..");
            Console.ReadLine();
        }
        #endregion

        private void ShowTableCustomer()
        {
            bool estado = true;
            Console.WriteLine("");
            Console.WriteLine("****RECUPERANDO DATOS - ESPERE POR FAVOR!*****");
            foreach (var customer in customerLogic.GetAllCustomers())
            {
                if (estado)
                {
                    TableGraphic.PrintLine();
                    TableGraphic.PrintRow("ID", "COMPAÑIA", "DIRECCIÓN",
                                          "CIUDAD", "REGION");
                    TableGraphic.PrintLine();
                    estado = false;
                }
                TableGraphic.PrintRow(customer.CustomerID.ToString(), customer.CompanyName,
                                      customer.Address, customer.City, customer.Region);
            }
            TableGraphic.PrintLine();
            Console.WriteLine("");
            Console.WriteLine("Presione Enter para volver al menu..");
            Console.ReadLine();
        }
    }

    
}
