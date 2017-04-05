using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ProjektniZadatakRadnaVerzija1.Models;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class AdresaController : Controller
    {
        public static int IzmenaAdrese(int sifraKorisnika, int sifraAdrese, string adresa, string broj, int? sifraGrada, int? sifraOpstine)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            try
            {
                string sqlUpit = "UPDATE adresa SET "
                                   + "adresa='" + adresa + "',"
                                   + "broj='" + broj + "',"
                                   + "sifraGrada='" + sifraGrada + "',"
                                   + "sifraOpstine='" + sifraOpstine + "'"
                                   + " WHERE sifraKorisnika='" + sifraKorisnika + "'"
                                   + " AND sifraAdrese='" + sifraAdrese + "'";

                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                konekcija.Open();
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

        public static int UnosAdreseKuca(int sifraKorisnika, string adresa, string broj, int sifraGrada, int sifraOpstine)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            
            try
            {
                string sqlUpit = "INSERT INTO adresa(adresa, broj, sifraTipaAdrese, sifraKorisnika, sifraGrada, sifraOpstine) "
                                       + "VALUES('" + adresa + "', '" + broj + "', 1, '" + sifraKorisnika + "', '" + sifraGrada + "', '" + sifraOpstine + "')";
                konekcija.Open();
                SqlCommand komandaUnosKorisnika = new SqlCommand(sqlUpit, konekcija);
                komandaUnosKorisnika.ExecuteNonQuery();
            }
            catch(Exception)
            {
                return  -1;
            }
            finally
            {
                
                konekcija.Close();
            }

            return 1;
        }


        public static int UnosAdresePosao(int sifraKorisnika, string adresa, string broj, int sifraGrada, int sifraOpstine)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            try
            {
                string sqlUpit = "INSERT INTO adresa(adresa, broj, sifraTipaAdrese, sifraKorisnika, sifraGrada, sifraOpstine) "
                                       + "VALUES('" + adresa + "', '" + broj + "', 2, '" + sifraKorisnika + "', '" + sifraGrada + "', '" + sifraOpstine + "')";

                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                konekcija.Open();
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

        public static int UnosAdreseLicnaKarta(int sifraKorisnika, string adresa, string broj, int sifraGrada, int sifraOpstine)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            try
            {
                string sqlUpit = "INSERT INTO adresa(adresa, broj, sifraTipaAdrese, sifraKorisnika, sifraGrada, sifraOpstine) "
                                       + "VALUES('" + adresa + "', '" + broj + "', 3, '" + sifraKorisnika + "', '" + sifraGrada + "', '" + sifraOpstine + "')";

                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                konekcija.Open();
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