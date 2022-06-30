using App.TP4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TP7.Service
{
    public interface ISuppliersService
    {
        List<Suppliers> GetAllSuppliers();
        void AddSupplier(Suppliers supplier);
        void DeleteSupplier(int id);
        void UpdateSupplier(Suppliers supplier);
        Suppliers GetSupplierById(int id);
    }
}
