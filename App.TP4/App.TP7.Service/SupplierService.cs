using App.TP4.Entities;
using App.TP4.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.TP7.Service
{
    public class SupplierService : ISuppliersService 
    {

        SuppliersLogic supplierLogic = new SuppliersLogic();
            
        public Suppliers GetSupplierById(int id)
        {
            try
            {
                return supplierLogic.GetById(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void AddSupplier(Suppliers supplier)
        {
            try
            {
                supplierLogic.Insert(supplier);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Suppliers> GetAllSuppliers()
        {
            try
            {
                return supplierLogic.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSupplier(int id)
        {
            try
            {
                supplierLogic.Delete(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateSupplier(Suppliers supplier)
        {
            try
            {
                supplierLogic.Update(supplier);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
