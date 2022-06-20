using App.TP4.Entities;
using App.TP4.Logic;
using App.TP7.MVC.Models;
using App.TP7.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.TP7.MVC.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISuppliersService Service; 
        
        public SupplierController()
        {
            Service = new SupplierService();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Supplier
        public ActionResult ListAll()
        {
            try
            {
                var suppliersList = Service.GetAllSuppliers().Select(s => new SupplierResponseView
                {
                    Id = s.SupplierID,
                    NameCompany = s.CompanyName,
                    Address = s.Address,
                    City = s.City,
                    Phone = s.Phone
                }).ToList();
                return View("Index", suppliersList);
            }
            catch(Exception)
            {
                return RedirectToAction("Index","Error");
            }
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SupplierResponseView suppplerView)
        {
            try
            {
                var supplierEntity = new Suppliers
                {
                    CompanyName = suppplerView.NameCompany,
                    Address = suppplerView.Address,
                    City = suppplerView.City,
                    Phone = suppplerView.Phone
                };

                Service.AddSupplier(supplierEntity);

                return RedirectToAction("ListAll");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        //GET: Supplier/Edit
        public ActionResult Edit(int id)
        {
            var supplier = Service.GetSupplierById(id);
            var supplierEdit = new SupplierRequestView()
            {
                NameCompany = supplier.CompanyName,
                Address = supplier.Address,
                City = supplier.City,
                Phone = supplier.Phone
            };
            return View(supplierEdit);
        }

        [HttpPost]
        public ActionResult Edit(SupplierResponseView supplierModel)
        {
            try
            {
                var supplierEdit = new Suppliers
                {
                    SupplierID = supplierModel.Id,
                    CompanyName = supplierModel.NameCompany,
                    Address = supplierModel.Address,
                    City = supplierModel.City,
                    Phone = supplierModel.Phone
                };

                Service.UpdateSupplier(supplierEdit);

                return RedirectToAction("ListAll");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Service.DeleteSupplier(id);
                return RedirectToAction("ListAll");
            }
            catch(Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}