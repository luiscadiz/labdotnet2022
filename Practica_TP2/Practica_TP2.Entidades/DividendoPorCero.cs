using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_TP2.Entidades
{
    public class DividendoPorCero : DivideByZeroException
    {
        private string _message = $"Solo el Equipo de Neoris puede dividir por cero!\n";
        public override string Message => _message + base.Message;
                        
        public DividendoPorCero() : base()
        {

        }
    }
}
