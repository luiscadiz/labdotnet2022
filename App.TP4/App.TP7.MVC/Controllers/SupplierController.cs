using App.TP4.Entities;
using App.TP4.Logic;
using App.TP7.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.TP7.MVC.Controllers
{
    public class SupplierController : Controller
    {
        SuppliersLogic LogicSupplier = new SuppliersLogic();
        // GET: Supplier
        public ActionResult Index()
        {
            List<Suppliers> suppliers = LogicSupplier.GetAll();
            List<SupplierView> supplierView = suppliers.Select(s => new SupplierView
            {
                Id = s.SupplierID,
                NameCompany = s.CompanyName
            }).ToList();
            return View(supplierView);
        }

        public ActionResult Insert()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Insert(SupplierView suppplerView)
        {
            try
            {
                var supplierEntity = new Suppliers { CompanyName = suppplerView.NameCompany };

                LogicSupplier.Insert(supplierEntity);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            LogicSupplier.Delete(id);
            return RedirectToAction("Index");
        }
    }
}