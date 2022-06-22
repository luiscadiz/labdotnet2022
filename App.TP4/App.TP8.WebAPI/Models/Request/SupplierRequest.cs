using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.TP8.WebAPI.Models
{
    public class SupplierRequest
    {
        public string NameCompany { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

    }
}