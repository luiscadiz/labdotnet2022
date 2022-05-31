using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_TP2.Entidades
{
    public class Logic
    {
        public static void DispararExcepcion()
        {
            throw new Exception();
        }

        public static void DispararExepcionPersonalizada()
        {
            throw new ExcepcionPersonalizada("Disparando una exepción personalida!");
        }
    }
}
