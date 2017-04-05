using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ProjektniZadatakRadnaVerzija1.Models;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class FiksniTelefonController : Controller
    {
        // GET: FiksniTelefon
        public ActionResult Index()
        {
            return View();
        }

        //Metoda koja sluzi za izmenu svih fiksnih telefona(kucnih i poslovnih)
        public static int IzmenaFiksnogTelefona(int sifraTelefona, string brojTelefona, int? lokalFiksni)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            try
            {
                string sqlUpit = "UPDATE kontaktTelefon SET "
                                 + "brojTelefona='" + brojTelefona + "'"
                                 + " WHERE sifraTelefona='" + sifraTelefona + "'";

                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                konekcija.Open();
                komanda.ExecuteNonQuery();

                string sqlUpdateFiksni = "UPDATE fiksniTelefon SET "
                                  + "sifraLokala='" + lokalFiksni + "'"
                                  + " WHERE sifraTelefona='" + sifraTelefona + "'";

                SqlCommand komandaFiksni = new SqlCommand(sqlUpdateFiksni, konekcija);
                komandaFiksni.ExecuteNonQuery();

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
        //Metoda koja sluzi za unos poslovnog fiksnog telefona
        public static int UnosPoslovnogFiksnogTelefona(int sifraKorisnika, string brojTelefona, int lokalFiksni)
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
              

                string sqlInsertFiksni = "INSERT INTO fiksniTelefon(sifraTelefona, sifraLokala, sifraTipaFiksnog) " +
                                          "VALUES('" + sifraTelefonaBaza + "', '" + lokalFiksni + "', 3)";

                SqlCommand komandaInsertFiksni = new SqlCommand(sqlInsertFiksni, konekcija);
                komandaInsertFiksni.ExecuteNonQuery();
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
        //Metoda koja sluzi za unos kucnog fiksnog telefona
        public static int UnosKucnogFiksnogTelefona(int sifraKorisnika, string brojTelefona, int lokalFiksni)
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


                string sqlInsertFiksni = "INSERT INTO fiksniTelefon(sifraTelefona, sifraLokala, sifraTipaFiksnog) " +
                                          "VALUES('" + sifraTelefonaBaza + "', '" + lokalFiksni + "', 6)";

                SqlCommand komandaInsertFiksni = new SqlCommand(sqlInsertFiksni, konekcija);
                komandaInsertFiksni.ExecuteNonQuery();
            }
            catch (Exception)
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