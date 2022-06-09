using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TP4.Logic
{ 
    public class DeleteSupplierException : Exception
    {
        private string _message = "No se logro eliminar el registro de la tabla";
        public override string Message => _message;

        public DeleteSupplierException() : base()
        {

        }

        public DeleteSupplierException(string message) : base(message)
        {

        }
    }
}
