using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TP4.Logic
{
    public class IdErrorExeption : Exception 
    {
        private string _message = "El ID ingresado no es valido!";
        public override string Message => _message;

        public IdErrorExeption() : base()
        {

        }

        public IdErrorExeption(string message)  : base(message)
        {

        }
}
}
