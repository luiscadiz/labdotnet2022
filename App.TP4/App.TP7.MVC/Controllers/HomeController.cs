using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Newtonsoft;
using System.Net.Http;
using System.Threading.Tasks;
using App.TP7.MVC.Models;
using Newtonsoft.Json;
using App.TP4.Entities;
using System.Net;

namespace App.TP7.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var url = "https://rickandmortyapi.com/api/character";
            WebClient client = new WebClient();
            var datos = client.DownloadString(url);
            var lista = JsonConvert.DeserializeObject<ModelsRickAndMortyView>(datos);
            return View(lista);

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