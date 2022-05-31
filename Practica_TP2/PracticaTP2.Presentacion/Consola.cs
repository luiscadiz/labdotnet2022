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
            //--------------EJERCICIO 1----------------
            int dividendo;
            System.Console.Write("Ingrese un dividendo: ");
            string entrada = System.Console.ReadLine();
            bool entradaValida = int.TryParse(entrada, out dividendo);
            if (entradaValida) IntentarDividirCero(dividendo);

            //----------EJERCICIO 2 --------------------
            System.Console.Write("Ingrese un dividendo: ");
            int num1 = int.Parse(System.Console.ReadLine());
            System.Console.Write("Ingrese un dividendo: ");
            int num2 = int.Parse(System.Console.ReadLine());
            int resultado = Dividir(num1, num2);
            Console.WriteLine($"El resultado es: {resultado}");
            //EJERCICIO 3
            try
            {
                Console.WriteLine("******PUNTO 3******S");
                Logic.DispararExcepcion();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Mensaje: {ex.Message} Tipo de excepción:\n " +
                                  $"Tipo: {ex.GetType().ToString()}");
            }
            finally
            {
                Console.WriteLine("Se termina el punto 3");
            }

            Console.ReadKey();

        }

        private static void IntentarDividirCero(int dividendo)
        {
            try
            {
                int resultado;
                resultado = dividendo / 0;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Se finalizó la operación");
            }
        }

        private static int Dividir(int dividendo, int divisor)
        {
            try
            {
                if(divisor != 0)
                    return dividendo / divisor;
                else
                   throw new DividendoPorCero();
            }
            catch (DividendoPorCero ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
                return 0;
            }
        }
    }
}
