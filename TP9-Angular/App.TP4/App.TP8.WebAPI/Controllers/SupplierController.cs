using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using App.TP4.Entities;
using App.TP4.Logic;
using App.TP8.WebAPI.Models;
using App.TP7.Service;
using System.Web.Http.Description;

namespace App.TP8.WebAPI.Controllers
{
    public class SupplierController : ApiController
    {
        private readonly ISuppliersService Service;

        public SupplierController()
        {
            Service = new SupplierService();
        }

        // GET: api/Supplier
        /// <summary>
        /// Obtiene todos los proveedores.
        /// </summary>        
        /// <response code="200">OK. Devuelve todos de proveedores solicitado.</response>        
        /// <response code="404">NotFound. No se logró devolver lo solicitado.</response>
        public IHttpActionResult Get()
        {
            try
            {
                var resp = Service.GetAllSuppliers();
             
                List<SupplierResponse> supplierList = resp.Select(s => new SupplierResponse()
                {
                    Id = s.SupplierID,
                    NameCompany = s.CompanyName,
                    Address = s.Address,
                    City = s.City,
                    Phone = s.Phone
                }).ToList();

                return Ok(supplierList);
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        // GET: api/Supplier/5
        /// <summary>
        /// Obtiene un proveedor por Id de la DB.
        /// </summary>
        /// <param name="id">Id del objeto.</param>              
        /// <response code="200">OK. Devuelve el proveedor solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el proveedor solicitado.</response>
        [ResponseType(typeof(SupplierResponse))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Suppliers supplierId = Service.GetSupplierById(id);
                var supplierResponse = new SupplierResponse()
                {
                    Id = supplierId.SupplierID,
                    NameCompany = supplierId.CompanyName,
                    Address = supplierId.Address,
                    City = supplierId.City,
                    Phone = supplierId.Phone
                };

                return Ok(supplierResponse);   
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        // POST: api/Supplier
        /// <summary>
        /// Crear un nuevo proveedor en la BD.
        /// </summary>
        /// <param name="supplierRequest">Proveedor a crear en la BD.</param>             
        /// <response code="201">Created. Proveedor correctamente creado en la BD.</response>        
        /// <response code="400">BadRequest. No se ha creado el Proveedor en la BD. Formato del proveedor incorrecto.</response>
        /// <response code="409">Conflict. El proveedor a crear ya existe en la BD.</response>
       [ResponseType(typeof(SupplierRequest))]
        public IHttpActionResult Post([FromBody] SupplierRequest supplierRequest)
        {
            try
            {
                var supplier = new Suppliers()
                {
                    CompanyName = supplierRequest.NameCompany,
                    Address = supplierRequest.Address,
                    City = supplierRequest.City,
                    Phone = supplierRequest.Phone
                };

                Service.AddSupplier(supplier);

                return Content(HttpStatusCode.Created, supplier);
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Supplier/5
        /// <summary>
        /// Editar un proveedor por Id.
        /// </summary>
        /// <param name="id">Id del proveedor.</param>              
        /// <response code="200">OK. Actualiza el proveedor solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el proveedor solicitado.</response>
        public IHttpActionResult Put(int id, [FromBody]SupplierModel supplierModel)
        {
            try
            {
                var supplierUpdate = new Suppliers
                {
                    SupplierID = id,
                    CompanyName = supplierModel.NameCompany,
                    Address = supplierModel.Address,
                    City = supplierModel.City,
                    Phone = supplierModel.Phone
                };
                Service.UpdateSupplier(supplierUpdate);
                return Ok(); 
            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Supplier/5
        /// <summary>
        /// Elimina un proveedor por Id.
        /// </summary>
        /// <param name="id">Id del proveedor.</param>              
        /// <response code="200">OK. Elimina el proveedor solicitado.</response>        
        /// <response code="500">NotFound. No se ha encontrado el proveedor solicitado.</response>
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Service.DeleteSupplier(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
