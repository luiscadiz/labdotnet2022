using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Transporte.Entidades;
using App_Transporte.Datos;

namespace App_Transporte.Presentacion
{
    internal class App
    {
        private static string[] options =
                                        {"Cargar nuevo Transporte",
                                        "Mostrar todos los Transportes",
                                        "Salir del programa"};
        private static string headTitle = @"
                                        ______ _                           _     _       
                                        | ___ (_)                         (_)   | |      
                                        | |_/ /_  ___ _ ____   _____ _ __  _  __| | ___  
                                        | ___ \ |/ _ \ '_ \ \ / / _ \ '_ \| |/ _` |/ _ \ 
                                        | |_/ / |  __/ | | \ V /  __/ | | | | (_| | (_) |
                                        \____/|_|\___|_| |_|\_/ \___|_| |_|_|\__,_|\___/ 
                                                                                                                                       
                                        ";


        public static void Start()
        {
            RepositorioOmnibus repositorioBus = new RepositorioOmnibus();
            RepositorioTaxi repositorioTaxis = new RepositorioTaxi();
            int opctionCurrent;
            Menu MainMenu = new Menu(headTitle, options);
            do
            {
                MainMenu.RunMenu();
                opctionCurrent = MainMenu.SelectedIndex;
                switch (opctionCurrent)
                {
                    case 0:
                        cargarTransporte(repositorioBus, repositorioTaxis);
                        break;
                    case 1:
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("************** TODOS LOS TRANSPORTES ********************");
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("");
                        repositorioBus.mostrarOmnibus();
                        Console.WriteLine(" ");
                        repositorioTaxis.mostrarTaxis();
                        Console.WriteLine("Presione una tecla para volver al menu");
                        Console.WriteLine("");
                        Console.ReadKey();
                        break;
                }
            } while (opctionCurrent >= 0 && opctionCurrent <= options.Length - 2);

            Console.WriteLine("Adios...");
        }

        private static void cargarTransporte(RepositorioOmnibus repoBus, RepositorioTaxi repoTaxi)
        {
            Console.Clear();
            int cantPasajeros;
            bool esValido;
            string subHeadTitle = "Seleccione el tipo de transporte";
            string[] options = { "Taxi", "Omnibus", "Volver" };
            Menu menuSelectionCar = new Menu(subHeadTitle, options);
            menuSelectionCar.RunMenu();
            switch (menuSelectionCar.SelectedIndex)
            {
                case 0:
                    do
                    {
                        Console.WriteLine("***CANTIDAD MAXIMA PERMITIDA: 4 PASAJEROS***");
                        Console.Write("Ingrese cantidad de pasajeros: ");
                        esValido = int.TryParse(Console.ReadLine(), out cantPasajeros);
                        if (!esValido) advertenciaCarga();
                        else if (!(cantPasajeros >= 1 && cantPasajeros <= 4))
                            advertenciaCarga();
                    } while(!(esValido && (cantPasajeros >=1 && cantPasajeros <=4)));
                    Taxi taxi = new Taxi(cantPasajeros);
                    repoTaxi.agregarTaxi(taxi);
                    cargaExitosa();
                    Console.ReadKey();
                    break;

                case 1:
                    do
                    {
                        Console.WriteLine("***CANTIDAD MAXIMA PERMITIDA: 100 PASAJEROS***");
                        Console.Write("Ingrese cantidad de pasajeros: ");
                        esValido = int.TryParse(Console.ReadLine(), out cantPasajeros);
                        if (!esValido) advertenciaCarga();
                        else if (!(cantPasajeros >= 1 && cantPasajeros <= 100))
                            advertenciaCarga();

                    } while (!(esValido && (cantPasajeros >= 1 && cantPasajeros <= 100)));
                    Omnibus omnibus = new Omnibus(cantPasajeros);
                    repoBus.agregarOmnibus(omnibus);
                    cargaExitosa();
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }

        private static void cargaExitosa()
        {
            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(">>>>>>>>--SE CARGO EXITOSAMENTE LOS PASAJEROS--<<<<<<<<<<");
            Console.WriteLine("---------------------------------------------------------");
            Console.Write("Presione una tecla para volver al menu____ ");
        }

        private static void advertenciaCarga()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine(">>--ADVERTENCIA--<< --> Ingresar datos validos!!");
            Console.WriteLine("----------------------------------------------------");
        }
    }
}
