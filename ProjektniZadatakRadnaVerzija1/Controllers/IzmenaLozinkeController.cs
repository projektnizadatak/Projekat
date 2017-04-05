using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ProjektniZadatakRadnaVerzija1.Models;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class IzmenaLozinkeController : Controller
    {
        // GET: IzmenaLozinke
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IzmenaLozinke()
        {
            /*Sa forme za izmenu lozinke se kupe vrednosti i nova lozinka se setuje na osnovu
            sifre korisnika */
            int sifraKorisnika = Convert.ToInt32(Request.Form["sifraKorisnika"]);
            string novaLozinka = Request.Form["lozinka"];

            try
            {
                string sqlUpit = "UPDATE korisnik SET lozinka='" + novaLozinka + "' WHERE id='" + sifraKorisnika + "'";
                BazaPodataka bazaPodataka = new BazaPodataka();
                bool izvrsenUpdate;
                izvrsenUpdate = bazaPodataka.AzuriranjePodatakaUBazi(sqlUpit);

                bazaPodataka.ZatvoriKonekciju();

                if (!izvrsenUpdate)
                {
                    string poruka = "Neuspesna izmena lozinke u bazi";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");
                }

                return View();
            }
            catch (Exception)
            {
                string poruka = "Izmena lozinke controller otkazao";
                Session["greska"] = poruka;
                return RedirectToAction("Index", "Greska");

            }

        }
    }
}