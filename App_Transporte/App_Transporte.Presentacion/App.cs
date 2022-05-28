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
                        repositorioBus.mostrarOmnibus();
                        Console.WriteLine(" ");
                        repositorioTaxis.mostrarTaxis();
                        Console.WriteLine("Presione una tecla para volver al menu");
                        Console.ReadKey();
                        break;
                }
            } while (opctionCurrent >= 0 && opctionCurrent <= options.Length - 2);

            Console.WriteLine("Adios...");
        }

        static void cargarTransporte(RepositorioOmnibus repoBus, RepositorioTaxi repoTaxi)
        {
            Console.Clear();
            int cantPasajeros;
            string subHeadTitle = "Seleccione el tipo de transporte";
            string[] options = { "Taxi", "Omnibus", "Volver" };
            Menu menuSelectionCar = new Menu(subHeadTitle, options);
            menuSelectionCar.RunMenu();
            switch (menuSelectionCar.SelectedIndex)
            {
                case 0:
                    Console.Write("Ingrese cantidad de pasajeros: ");
                    cantPasajeros = int.Parse(Console.ReadLine());
                    Taxi taxi = new Taxi(cantPasajeros);
                    repoTaxi.agregarTaxi(taxi);
                    Console.WriteLine("*******Se cargo pasajeros al taxi exitosamente******");
                    Console.Write("Presione una tecla para volver al menu ");
                    Console.ReadKey();
                    break;
                case 1:
                    Console.Write("Ingrese cantidad de pasajeros: ");
                    cantPasajeros = int.Parse(Console.ReadLine());
                    Omnibus omnibus = new Omnibus(cantPasajeros);
                    repoBus.agregarOmnibus(omnibus);
                    Console.WriteLine(" ");
                    Console.WriteLine("*******Se cargo pasajeros al omnibus exitosamente******");
                    Console.Write("Presione una tecla para volver al menu ");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
    }
}
