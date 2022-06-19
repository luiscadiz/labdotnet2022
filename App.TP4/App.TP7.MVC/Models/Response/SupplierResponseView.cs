using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.TP7.MVC.Models
{
    public class SupplierResponseView
    {
        [Display(Name = "Id")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Compañia")]
        [Required]
        public string NameCompany { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(60)]
        public string Address { get; set; }

        [Display(Name = "Ciudad")]
        [StringLength(60)]
        public string City { get; set; }

        [Display(Name = "Telefono")]
        [StringLength(24)]
        public string Phone { get; set; }
    }
}