using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_TP2.Entidades
{
    public class ExcepcionPersonalizada : Exception
    {
        public override string Message => base.Message;

        public ExcepcionPersonalizada(string mensaje) : base(mensaje)
        {

        }
    }
}
