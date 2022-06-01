using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_TP2.Entidades
{
    public static class IntExtension
    {
        public static int IntentarDividirCero(this int value)
        {
            try
            {
                return value / 0;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                Console.WriteLine("Se finalizó la operación.");
            }
        }

        public static int DividirPor(this int value, int divisor)
        {
            try
            {
                if (divisor != 0)
                    return value / divisor;
                else
                    throw new DividendoPorCero();
            }
            catch (DividendoPorCero ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
