using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Transporte.Entidades
{
    public abstract class TransportePublico : ITransporte
    {
        private int _pasajeros;
        public int Pasajeros { get => _pasajeros; set => _pasajeros = value; }

        public TransportePublico(int cantPasajeros)
        {
            this._pasajeros = cantPasajeros;
        }

        public abstract string Avanzar();

        public abstract string Detenerse();

        public abstract void MostrarDatos();
    }
}