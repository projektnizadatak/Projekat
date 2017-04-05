using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ProjektniZadatakRadnaVerzija1.Models;
namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class SlikaKorisnikaController : Controller
    {
        //Metoda koja sluzi za postavljanje slike korisnika
        public static int PostavljaneSlikeKorisniku(int sifraKorisnika, string putanjaFotografije)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            try
            {

                string sqlFotografija = "UPDATE korisnik SET fotografija='" + putanjaFotografije + "'" +
                                        "WHERE id=" + sifraKorisnika;
                konekcija.Open();
                SqlCommand komanda = new SqlCommand(sqlFotografija, konekcija);
                komanda.ExecuteNonQuery();
            }
            catch(Exception)
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