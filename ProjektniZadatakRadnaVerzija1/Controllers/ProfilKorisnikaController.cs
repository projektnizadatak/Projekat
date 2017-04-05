using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class ProfilKorisnikaController : Controller
    {
        // GET: ProfilKorisnika
        public ActionResult Index(int? id)
        {
            if(id!=null)
            {
                Session["id"] = id;
            }
            return View();
        }
        public ActionResult ProfilKorisnikaPregled(int id)
        {
            Session["id"] = id;
            return View();
        }
        public ActionResult ProfilKorisnikaUnos(int id)
        {
            Session["id"] = id;
            return View();
        }
    }
}