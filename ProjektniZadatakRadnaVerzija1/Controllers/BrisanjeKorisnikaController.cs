using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektniZadatakRadnaVerzija1.Models;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class BrisanjeKorisnikaController : Controller
    {
        // GET: BrisanjeKorisnika
        public ActionResult BrisanjeKorisnikaIzBaze(int id)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
           
            try
            {
                
                //BRISANJE SVIH MOBILNIH I FIKSNIH TELEFONA ODREDJENOG KORISNIKA
                ////////////////////////////////////////////////////////////////

                string sqlUpit1 = "DELETE FROM mobilniTelefon "
                    + "WHERE sifraTelefona in(SELECT sifraTelefona FROM kontaktTelefon WHERE sifraKorisnika='" + id + "')";

                string sqlUpit2 = "DELETE FROM fiksniTelefon "
                    + "WHERE sifraTelefona in(SELECT sifraTelefona FROM kontaktTelefon WHERE sifraKorisnika='" + id + "')";

                string sqlUpit3 = "DELETE FROM kontaktTelefon "
                    + "WHERE sifraKorisnika='" + id + "'";

                konekcija.Open();
                try
                {
                    //Brisanje iz tabele mobilniTelefon
                    SqlCommand komanda = new SqlCommand(sqlUpit1, konekcija);
                    komanda.ExecuteNonQuery();

                }
                catch (Exception)
                {
                    string poruka = "//Brisanje iz tabele mobilniTelefon BrisanjeKorisnikController";
                    Session["greska"] = poruka;
                    RedirectToAction("Index", "Greska");
                }

                try
                {
                    //Brisanje iz tabele fiksniTelefon
                    SqlCommand komanda = new SqlCommand(sqlUpit2, konekcija);
                    komanda.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string poruka = " //Brisanje iz tabele fiksniTelefon BrisanjeKorisnikController";
                    Session["greska"] = poruka;
                    RedirectToAction("Index", "Greska");

                }
                //BRISANJE SVIH ADRESA I EMAIL ADRESA ODREDJENOG KORISNIKA
                //////////////////////////////////////////////////////////
                try
                {
                    //Brisanje iz tabele kontaktTelefon
                    SqlCommand komanda = new SqlCommand(sqlUpit3, konekcija);
                    komanda.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string poruka = "//Brisanje iz tabele kontaktTelefon  BrisanjeKorisnikController";
                    Session["greska"] = poruka;
                    RedirectToAction("Index", "Greska");

                }

                string sqlUpit4 = "DELETE FROM adresa WHERE sifraKorisnika='" + id + "'";
                string sqlUpit5 = "DELETE FROM emailAdresa WHERE sifraKorisnika='" + id + "'";
                try
                {

                    //Brisanje iz tabele adresa
                    SqlCommand komanda = new SqlCommand(sqlUpit4, konekcija);
                    komanda.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string poruka = "//Brisanje iz tabele adresa BrisanjeKorisnikController";
                    Session["greska"] = poruka;
                    RedirectToAction("Index", "Greska");

                }

                try
                {
                    //Brisanje iz tabele emailAdresa
                    SqlCommand komanda = new SqlCommand(sqlUpit5, konekcija);
                    komanda.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string poruka = " //Brisanje iz tabele emailAdresa BrisanjeKorisnikController";
                    Session["greska"] = poruka;
                    RedirectToAction("Index", "Greska");

                }


                //BRISANJE KORISNIKA 
                ////////////////////
                try
                {
                //Brisanje iz tabele korisnik
                string sqlUpit6 = "DELETE FROM korisnik WHERE id='"+id+"'";
                    SqlCommand komanda = new SqlCommand(sqlUpit6, konekcija);
                    komanda.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string poruka = "//Brisanje iz tabele korisnik BrisanjeKorisnikController";
                    Session["greska"] = poruka;
                    RedirectToAction("Index", "Greska");

                }
                

                Korisnik korisnik = (Korisnik)Session["korisnik"];
                PravoPristupa pravoPristupa = PravoPristupa.VratiPravoPristupa(korisnik.SifraPravaPristupa);

                

                //Na osnovu prava pristupa se vrsi redirekcija na odredjene strane
                if (pravoPristupa.NazivPristupa == "Pravo administracije")
                {
                    return RedirectToAction("PocetnaAdmin", "Logovanje");

                }
                else if (pravoPristupa.NazivPristupa == "Pravo unosa")
                {
                    return RedirectToAction("PocetnaKorisnikUnos", "Logovanje");

                }
                else if (pravoPristupa.NazivPristupa == "Pravo pregleda")
                {
                    return RedirectToAction("PocetnaKorisnikPregled", "Logovanje");
                }
                else
                {
                    string poruka = "Korisnik nema pravo pristupa";
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
                konekcija.Close();
            }
        }
    }
}