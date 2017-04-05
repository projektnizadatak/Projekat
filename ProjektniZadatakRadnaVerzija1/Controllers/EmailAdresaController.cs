using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ProjektniZadatakRadnaVerzija1.Models;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class EmailAdresaController : Controller
    {
        // GET: EmailAdresa
        public ActionResult Index()
        {
            return View();
        }

        //Metoda koja sluzi za izmenu svih email adresa(privatnih i poslovnih)
        public static int izmeniEmailAdresu(int sifraEmailAdrese, string email)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            try
            {
                string sqlUpit = "UPDATE emailAdresa SET "
                                   + "email='" + email + "'"
                                   + " WHERE sifraEmail='" + sifraEmailAdrese + "'";
                konekcija.Open();
                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                komanda.ExecuteNonQuery();
            }
            catch (Exception)
            { 
                return -1;
            }
            finally
            {
                konekcija.Close();
            }

            return 1;
        }

        //Metoda koja sluzi za unosenje privatnih email adresa
        public static int UnesiPrivatnuEmailAdresu(int sifraKorisnika, string email)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            try
            {
                string sqlUpit = "INSERT INTO emailAdresa(email, sifraTipaEmail, sifraKorisnika) "
                                        + "VALUES('" + email + "', 1,'" + sifraKorisnika + "')";

                konekcija.Open();
                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                konekcija.Close();
            }
            return 1;
        }
        //Metoda koja sluzi za unosenje poslovnih email adresa
        public static int UnesiPoslovnuEmailAdresu(int sifraKorisnika, string email)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            try
            {
                string sqlUpit = "INSERT INTO emailAdresa(email, sifraTipaEmail, sifraKorisnika) "
                                        + "VALUES('" + email + "', 2,'" + sifraKorisnika + "')";
                konekcija.Open();
                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                konekcija.Close();
            }
            return 1;
        }
    
    }
}