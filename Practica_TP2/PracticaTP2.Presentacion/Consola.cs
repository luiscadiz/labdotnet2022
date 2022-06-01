using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica_TP2.Entidades;

namespace PracticaTP2.Presentacion
{
    public static class Consola
    {
        public static void Start()
        {
            Consola.PuntoUno();
            Consola.PuntoDos();
            Consola.PuntoTres();
            Consola.PuntoCuatro();
            Console.ReadKey();
        }

        private static void PuntoUno()
        {
            int numero;
            string titulo = "----------PUNTO 1 ----------";
            Console.WriteLine(titulo);
            Console.Write("Ingrese un numero: ");
            bool entradaValida = int.TryParse(Console.ReadLine(), out numero);
            if (entradaValida) numero.IntentarDividirCero();
            else
                Console.WriteLine("No ingreso un numero");
            Console.WriteLine("Presione enter para continuar con el siguiente punto:");
            Console.ReadKey();
            Console.WriteLine("");
        }
        private static void PuntoDos()
        {
            try
            {
                string titulo = "----------PUNTO 2 ----------";
                Console.WriteLine(titulo);
                Console.Write("Ingrese un dividendo: ");
                int dividendo = int.Parse(Console.ReadLine());
                Console.Write("Ingrese un divisor: ");
                int divisor = int.Parse(Console.ReadLine());
                int resultado = dividendo.DividirPor(divisor);
                Console.WriteLine($"El resultado es: {resultado}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Seguro Ingreso una letra o no ingreso nada");
            }
            finally
            {
                Console.WriteLine("Presione enter para continuar con el siguiente punto:");
                Console.ReadKey();
                Console.WriteLine("");
            }
        }

        private static void PuntoTres()
        {
            try
            {
                string titulo = "----------PUNTO 3 ----------";
                Console.WriteLine(titulo);
                Logic.DispararExcepcion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mensaje: {ex.Message}\n " + 
                                  $"Tipo de excepción: {ex.GetType().ToString()}");
            }
            finally
            {
                Console.WriteLine("Presione enter para continuar con el siguiente punto:");
                Console.ReadKey();
                Console.WriteLine("");
            }
        }

        private static void PuntoCuatro()
        {
            try
            {
                string titulo = "----------PUNTO 4 ----------";
                Console.WriteLine(titulo);
                Logic.DispararExepcionPersonalizada();
            }
            catch (ExcepcionPersonalizada exp)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"{exp.Message}");
                Console.WriteLine("-------------------------------------------");
            }
            finally
            {
                Console.WriteLine("Se termina el punto 4");
                Console.WriteLine("");
            }
        }  
    }
}
