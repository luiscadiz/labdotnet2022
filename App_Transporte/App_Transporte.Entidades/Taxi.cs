using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Transporte.Entidades
{
    public class Taxi : TransportePublico
    {
        public static int contadorTaxis;
        private int nroTaxi;
        public Taxi(int cantPasajeros) : base(cantPasajeros)
        {
            nroTaxi = Taxi.contadorTaxis;
            Taxi.contadorTaxis++;
        }

        static Taxi()
        {
            contadorTaxis = 1;
        }

        public override string Avanzar()
        {
            return $"El Taxi {contadorTaxis} esta avanzando";
        }

        public override string Detenerse()
        {
            return $"El Taxi {contadorTaxis} se detuvo";
        }

        public override void MostrarDatos()
        {
            Console.WriteLine($"Taxi {nroTaxi}: {Pasajeros} pasajeros");
        }
    }
}