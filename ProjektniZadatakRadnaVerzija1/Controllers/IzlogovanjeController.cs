using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class IzlogovanjeController : Controller
    {
        // GET: Izlogovanje
        public ActionResult Index()
        {
            Session.Clear();
            Session["porukaIzlogovanje"] = "Hvala na poseti!";
            return RedirectToAction("Index", "Logovanje");
        }
    }
}