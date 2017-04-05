using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ProjektniZadatakRadnaVerzija1.Models;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class MobilniTelefonController : Controller
    {
        // GET: MobilniTelefon
        public ActionResult Index()
        {
            return View();
        }
       
        //Metoda koja sluzi za izmenu svih mobilnih telefona(privatnih i sluzbenih)
        public static int IzmenaMobilnogTelefona(int sifraTelefona, string brojTelefona, int? lokalMobilni)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            try
            {
                string sqlUpit = "UPDATE kontaktTelefon SET "
                                 + "brojTelefona='" + brojTelefona + "'"
                                 + " WHERE sifraTelefona='" + sifraTelefona + "'";
                konekcija.Open();
                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                komanda.ExecuteNonQuery();

                string sqlUpdateMobilni = "UPDATE mobilniTelefon SET "
                                  + "sifraLokala='" + lokalMobilni + "'"
                                  + " WHERE sifraTelefona='" + sifraTelefona + "'";

                SqlCommand komandaUpdateMobilni = new SqlCommand(sqlUpdateMobilni, konekcija);
                komandaUpdateMobilni.ExecuteNonQuery();

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

        //Metoda koja sluzi za unos privatnog mobilnog telefona
        public static int UnosPrivatnogMobilnogTelefona(int sifraKorisnika, string brojTelefona, int lokalMobilni)
        {

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            try
            {
                string sqlInsertTelefon = "INSERT INTO kontaktTelefon(brojTelefona, sifraKorisnika) "
                                        + "VALUES('" + brojTelefona + "','" + sifraKorisnika + "')";

                konekcija.Open();
                SqlCommand komanda = new SqlCommand(sqlInsertTelefon, konekcija);
                komanda.ExecuteNonQuery(); 

                string sqlSifraTelefona = "SELECT MAX(sifraTelefona) as sifraTelefona FROM kontaktTelefon";

                SqlCommand komandaSifraTelefona = new SqlCommand(sqlSifraTelefona, konekcija);

                reader = komandaSifraTelefona.ExecuteReader();

                int sifraTelefonaBaza = 0;

                if (reader != null)
                {
                    if (reader.Read())
                    {
                        sifraTelefonaBaza = Convert.ToInt32(reader["sifraTelefona"]);
                    }
                }

                string sqlInsertMobilni = "INSERT INTO mobilniTelefon(sifraTelefona, sifraLokala, sifraTipaMobilnog) " +
                                          "VALUES('" + sifraTelefonaBaza + "', '" + lokalMobilni + "', 1)";

                SqlCommand komandaInsertMobilni = new SqlCommand(sqlInsertMobilni, konekcija);
                komandaInsertMobilni.ExecuteNonQuery();
            }
            catch(Exception)
            {
                return -1;
            }
            finally
            {
                reader.Close();
                konekcija.Close();
            }
            return 1;

        }
        //Metoda koja sluzi za unos sluzbenog mobilnog telefona
        public static int UnosSluzbenogMobilnogTelefona(int sifraKorisnika, string brojTelefona, int lokalMobilni)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            try
            {
                string sqlInsertTelefon = "INSERT INTO kontaktTelefon(brojTelefona, sifraKorisnika) "
                                        + "VALUES('" + brojTelefona + "','" + sifraKorisnika + "')";

                konekcija.Open();
                SqlCommand komanda = new SqlCommand(sqlInsertTelefon, konekcija);
                komanda.ExecuteNonQuery();

                string sqlSifraTelefona = "SELECT MAX(sifraTelefona) as sifraTelefona FROM kontaktTelefon";

                SqlCommand komandaSifraTelefona = new SqlCommand(sqlSifraTelefona, konekcija);
                reader = komandaSifraTelefona.ExecuteReader();

                int sifraTelefonaBaza = 0;

                if (reader != null)
                {
                    if (reader.Read())
                    {
                        sifraTelefonaBaza = Convert.ToInt32(reader["sifraTelefona"]);
                    }
                }
        
                string sqlInsertMobilni = "INSERT INTO mobilniTelefon(sifraTelefona, sifraLokala, sifraTipaMobilnog) " +
                                          "VALUES('" + sifraTelefonaBaza + "', '" + lokalMobilni + "', 2)";

                SqlCommand komandaInsertMobilni = new SqlCommand(sqlInsertMobilni, konekcija);
                komandaInsertMobilni.ExecuteNonQuery();
            }
            catch(Exception)
            {
                return -1;
            }
            finally
            {
                reader.Close();
                konekcija.Close();
            }

            return 1;

        }
    }
}