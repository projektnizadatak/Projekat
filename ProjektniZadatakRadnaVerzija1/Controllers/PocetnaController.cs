using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektniZadatakRadnaVerzija1.Models;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class PocetnaController : Controller
    {
        // GET: Pocetna
        public ActionResult Index()
        {
            try
            {
                string sqlUpit = "SELECT * FROM korisnik WHERE popunjen='1'";

                BazaPodataka bazaPodataka = new BazaPodataka();
                SqlDataReader reader = bazaPodataka.CitanjePodatakaIzBaze(sqlUpit);

                List<Korisnik> listaPopunjenihKorisnika = new List<Korisnik>();

                while (reader.Read())
                {
                    listaPopunjenihKorisnika.Add(new Korisnik(Convert.ToInt32(reader["id"]),
                       Convert.ToString(reader["korisnickoIme"]), Convert.ToString(reader["lozinka"]),
                       Convert.ToInt32(reader["sifraPravaPristupa"]), Convert.ToString(reader["ime"]),
                       Convert.ToString(reader["prezime"]), Convert.ToString(reader["imeRoditelja"]),
                       Convert.ToString(reader["jmbg"]), Convert.ToString(reader["brojLicneKarte"]),
                       Convert.ToDateTime(reader["datumRodjenja"]), Convert.ToInt32(reader["sifraMestaRodjenja"]),
                       Convert.ToInt32(reader["sifraOpstineRodjenja"]), Convert.ToInt32(reader["sifraPola"]),
                       Convert.ToString(reader["fotografija"]), Convert.ToString(reader["beleska"])
                       ));
                }
                reader.Close();
                bazaPodataka.ZatvoriKonekciju();

                Session["listaPopunjenihKorisnika"] = listaPopunjenihKorisnika;

                return View();
            }
            catch (Exception)
            {
                string poruka = "PocetnaController otkazao";
                Session["greska"] = poruka;
                return RedirectToAction("Index", "Greska");

            }


        }
    }
}