using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.ReadKey();

        }

        public static void IntentarDividirCero(int dividendo)
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
    }
}
