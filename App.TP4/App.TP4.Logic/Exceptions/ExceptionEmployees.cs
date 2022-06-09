using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TP4.Logic.Exceptions
{
    public class ExceptionEmployees : Exception 
    {
        public override string Message => $"Mensaje: {base.Message}";

        public ExceptionEmployees(string message)  : base(message)
        {

        }
    }
}
