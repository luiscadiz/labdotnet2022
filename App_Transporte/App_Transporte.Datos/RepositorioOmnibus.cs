using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Transporte.Entidades;

namespace App_Transporte.Datos
{
    public class RepositorioOmnibus
    {
        private List<Omnibus> omnibuses;

        public RepositorioOmnibus()
        {
            omnibuses = new List<Omnibus>();
        }

        public void agregarOmnibus(Omnibus bus)
        {
            omnibuses.Add(bus);
        }

        public void mostrarOmnibus()
        {
            int contador = 0;
            while (contador < 5)
            {
                if (contador < omnibuses.Count)
                {
                    omnibuses[contador].MostrarDatos();
                    contador++;
                }
                else
                {
                    contador++;
                    Console.WriteLine($"Omnibus {contador}: Sin pasajeros");
                }
            }
        }
    }
}