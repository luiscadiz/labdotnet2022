using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace App_Transporte.Entidades
{
    public class Omnibus : TransportePublico
    {
        public static int contadorOmnibus;
        private int nroOmnibus;
        public Omnibus(int cantPasajeros) : base(cantPasajeros)
        {
            nroOmnibus = Omnibus.contadorOmnibus;
            Omnibus.contadorOmnibus++;
        }

        static Omnibus()
        {
            contadorOmnibus = 1;
        }

        public override string Avanzar()
        {
            return $"El Omnibus {contadorOmnibus} esta avanzando";
        }

        public override string Detenerse()
        {
            return $"El omnnibus {contadorOmnibus} se detuvo";
        }

        public override void MostrarDatos()
        {
            Console.WriteLine($"Omnibus {nroOmnibus}: {Pasajeros} pasajeros");
        }
    }
}
