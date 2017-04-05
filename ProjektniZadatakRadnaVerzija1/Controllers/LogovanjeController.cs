using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektniZadatakRadnaVerzija1.Models;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class LogovanjeController : Controller
    {
        // GET: Logovanje
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Auautentifikacija()
        {
            /*
            Na osnovu prosledjenih parametara sa forme (korisnickoIme i lozinka) proverava se postojanje
            korisnika u bazi. Ukoliko postoji, pravi se objekat klase Korisnik i setuju se svi njegovi
            parametri koji su pokupljeni iz baze. Ukoliko ne postoji pojavice se odgovarajuca poruka.
            */
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;
            try
            {
                string korisnickoIme = Request.Form["korisnickoIme"];
                string lozinka = Request.Form["lozinka"];

                string sqlUpit = "SELECT * " +
                                 "FROM korisnik " +
                                 "WHERE korisnickoIme='" + korisnickoIme + "' and lozinka='" + lozinka + "'";
                konekcija.Open();
                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                reader = komanda.ExecuteReader();

                Korisnik korisnik = null;

                if (reader != null)
                {
                    try
                    {
                        if (reader.Read())
                        {
                            /*Sledeca polja su obavezna pri unosu novog korisnika u bazu
                            tako da nikada nece imati NULL vrednost*/
                            korisnik = new Korisnik();
                            korisnik.Id = Convert.ToInt32(reader["id"]);
                            korisnik.KorisnickoIme = Convert.ToString(reader["korisnickoIme"]);
                            korisnik.Lozinka = Convert.ToString(reader["lozinka"]);
                            korisnik.Ime = Convert.ToString(reader["ime"]);
                            korisnik.Prezime = Convert.ToString(reader["prezime"]);
                            korisnik.Jmbg = Convert.ToString(reader["jmbg"]);
                            korisnik.BrojLicneKarte = Convert.ToString(reader["brojLicneKarte"]);
                            korisnik.SifraPola = Convert.ToInt32(reader["sifraPola"]);
                            korisnik.SifraPravaPristupa = Convert.ToInt32(reader["sifraPravaPristupa"]);

                            /*Sledeca polja nisu obavezna pri unosu novog korisnika u bazu
                            tako da se pre setovanja propertija mora proveriti da li im je vrednost NULL*/
                            if (reader["imeRoditelja"] != DBNull.Value)
                            {
                                korisnik.ImeRoditelja = Convert.ToString(reader["imeRoditelja"]);
                            }
                            else
                            {
                                korisnik.ImeRoditelja = null;
                            }

                            if (reader["datumRodjenja"] != DBNull.Value)
                            {
                                korisnik.DatumRodjenja = Convert.ToDateTime(reader["datumRodjenja"]);
                            }
                            else
                            {
                                korisnik.DatumRodjenja = null;
                            }

                            if (reader["sifraMestaRodjenja"] != DBNull.Value)
                            {
                                korisnik.SifraMestaRodjenja = Convert.ToInt32(reader["sifraMestaRodjenja"]);
                            }
                            else
                            {
                                korisnik.SifraMestaRodjenja = 0;
                            }

                            if (reader["sifraOpstineRodjenja"] != DBNull.Value)
                            {
                                korisnik.SifraOpstineRodjenja = Convert.ToInt32(reader["sifraOpstineRodjenja"]);
                            }
                            else
                            {
                                korisnik.SifraOpstineRodjenja = 0;
                            }

                            if (reader["fotografija"] != DBNull.Value)
                            {
                                korisnik.Fotografija = Convert.ToString(reader["fotografija"]);
                            }
                            else
                            {
                                korisnik.Fotografija = null;
                            }

                            if (reader["beleska"] != DBNull.Value)
                            {
                                korisnik.Beleska = Convert.ToString(reader["beleska"]);
                            }
                            else
                            {
                                korisnik.Beleska = null;
                            }
                        }
                        else
                        {
                            string porukaLogovanje = "Korisnicko ime ne postoji ili ste pogresno uneli lozinku. Pokusajte ponovo.";
                            Session["porukaLogovanje"] = porukaLogovanje;
                            return RedirectToAction("Index");
                        }
                    }

                    catch (Exception)
                    {
                        string poruka = "Logovanje controller otkazao";
                        Session["greska"] = poruka;
                        RedirectToAction("Index", "Greska");
                    }

                    PravoPristupa pravoPristupa = PravoPristupa.VratiPravoPristupa(korisnik.SifraPravaPristupa);
                    Session["korisnik"] = korisnik;

                    //Na osnovu prava pristupa se vrsi redirekcija na odredjene strane
                    if (pravoPristupa.NazivPristupa == "Pravo administracije")
                    {
                        return RedirectToAction("PocetnaAdmin");

                    }
                    else if (pravoPristupa.NazivPristupa == "Pravo unosa")
                    {
                        return RedirectToAction("PocetnaKorisnikUnos");

                    }
                    else if (pravoPristupa.NazivPristupa == "Pravo pregleda")
                    {
                        return RedirectToAction("PocetnaKorisnikPregled");
                    }
                    else
                    {
                        string poruka = "Pravo pristupa nije dodeljeno korisniku.";
                        Session["greska"] = poruka;
                        return RedirectToAction("Index", "Greska");
                    }
                }
                else
                {
                    string poruka = "SqlDataReader vraca null vrednost";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");
                }
            }
            catch (Exception ex)
            {
                Session["greska"] = ex.Message;
                return RedirectToAction("Index", "Greska");
            }
            finally
            {
                reader.Close();
                konekcija.Close();
            }

        }

        public ActionResult PocetnaAdmin()
        {
            return View();
        }
        public ActionResult PocetnaKorisnikPregled()
        {
            return View();
        }
        public ActionResult PocetnaKorisnikUnos()
        {
            return View();
        }
    }
}