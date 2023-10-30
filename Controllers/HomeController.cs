using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using Adondevamos.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Profile;
using Microsoft.Extensions.Logging;

namespace Adondevamos.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection sqlc = new SqlConnection("Data Source=Elio;Initial Catalog=Login;Integrated Security=True");

        public ActionResult Index()
        {
            return View();
        }


        //[HttpPost]
        public ActionResult Loginn()
        {
            ViewBag.Login = "active";
            return View();


        }



        public ActionResult sala()
        {
            ViewBag.Login = "active";
            return View();
        }
    }
}






