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
            System.Console.Write("Ingrese un dividendo: ");
            bool entradaValida = int.TryParse(Console.ReadLine(), out numero);
            if (entradaValida) numero.IntentarDividirCero();
        }

        private static void PuntoDos()
        {
            System.Console.Write("Ingrese un dividendo: ");
            int num1 = int.Parse(System.Console.ReadLine());
            System.Console.Write("Ingrese un dividendo: ");
            int num2 = int.Parse(System.Console.ReadLine());
            int resultado = num1.Dividir(num2);
            Console.WriteLine($"El resultado es: {resultado}");
        }

        private static void PuntoTres()
        {
            Console.WriteLine("******PUNTO 3******S");
            try
            {
                Logic.DispararExcepcion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mensaje: {ex.Message}\n " +
                                  $"Tipo de excepción: {ex.GetType().ToString()}");
            }
            finally
            {
                Console.WriteLine("Se termina el punto 3");
            }
        }

        private static void PuntoCuatro()
        {
            try
            {
                Logic.DispararExepcionPersonalizada();
            }
            catch (ExcepcionPersonalizada exp)
            {
                Console.WriteLine($"Mensaje: {exp.Message}\n Tipo: {exp.GetType().ToString()} ");

            }
            finally
            {
                Console.WriteLine("Se termina el punto 4");
            }
        }  
    }
}
