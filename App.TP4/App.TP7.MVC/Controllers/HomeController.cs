using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.TP4.Logic;


namespace App.TP7.MVC.Controllers
{
    public class HomeController : Controller
    {

        RickAndMortyLogic rickAndMortylogic = new RickAndMortyLogic();

        // GET: RickAndMoty
        public ActionResult Index()
        {
            var listCharacters = rickAndMortylogic.GetCharacters();

            return View(listCharacters);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}