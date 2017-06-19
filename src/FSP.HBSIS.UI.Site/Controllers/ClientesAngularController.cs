using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FSP.HBSIS.UI.Site.Controllers
{
    public class ClientesAngularController : Controller
    {
        // GET: ClientesAngular
        public ActionResult Index()
        {
            //return View();
            var result = new FilePathResult($"~/Views/List.html", "text/html");
            return result;
        }
    }
}