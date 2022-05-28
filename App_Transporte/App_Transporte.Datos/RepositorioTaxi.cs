using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Transporte.Entidades;

namespace App_Transporte.Datos
{
    public class RepositorioTaxi
    {
        private List<Taxi> Taxis;

        public RepositorioTaxi()
        {
            Taxis = new List<Taxi>();
        }
        public void agregarTaxi(Taxi taxi)
        {
            Taxis.Add(taxi);
        }

        public void mostrarTaxis()
        {
            int contador = 0;
            while (contador < 5)
            {
                if (contador < Taxis.Count)
                {
                    Taxis[contador].MostrarDatos();
                    contador++;
                }
                else
                {
                    contador++;
                    Console.WriteLine($"Taxi {contador}: 0 pasajeros");

                }
            }
        }

    }
}
