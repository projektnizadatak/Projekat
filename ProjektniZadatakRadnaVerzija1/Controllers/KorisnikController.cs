using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ProjektniZadatakRadnaVerzija1.Models;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class KorisnikController : Controller
    {
        public KorisnikController()
        {

        }

        public int UnosOsnovnihPodatakaKorisnika(string korisnickoIme, string lozinka, int sifraPristupa, string ime, string prezime, string jmbg, string brojLicneKarte, int sifraPola)
        {
            int sifraKorisnika = -1;
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            try
            {
                string sqlUpit = "INSERT INTO korisnik(korisnickoIme, lozinka, sifraPravaPristupa, ime, prezime, jmbg, brojLicneKarte, sifraPola) " +
                                        "VALUES ('" + korisnickoIme + "', '" + lozinka + "', '" + sifraPristupa + "','" + ime + "', '" + prezime + "', '" + jmbg + "', '" + brojLicneKarte + "', '" + sifraPola + "')";

                konekcija.Open();
                SqlCommand komandaUnosKorisnika = new SqlCommand(sqlUpit, konekcija);
                komandaUnosKorisnika.ExecuteNonQuery();

                string sqlSifraKorisnika = "SELECT MAX(id) as sifraKorisnika FROM korisnik";

                SqlCommand komandaSifraKorisnika = new SqlCommand(sqlSifraKorisnika, konekcija);

                reader = komandaSifraKorisnika.ExecuteReader();
                
                if (reader != null)
                {
                    if (reader.Read())
                        sifraKorisnika = Convert.ToInt32(reader["sifraKorisnika"]);
                }
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

            return sifraKorisnika;
        }


        public int IzmenaOsnovnihPodatakaKorisnika(int sifraKorisnika, string lozinka, int sifraPristupa, string ime, string prezime, string jmbg, string brojLicneKarte, int sifraPola)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            
            try
            {

                string sqlUpit = "UPDATE korisnik SET "
                          + "sifraPravaPristupa='" + sifraPristupa + "',"
                          + "lozinka='" + lozinka + "',"
                          + "ime='" + ime + "',"
                          + "prezime='" + prezime + "',"
                          + "jmbg='" + jmbg + "',"
                          + "brojLicneKarte='" + brojLicneKarte + "',"
                          + "sifraPola='" + sifraPola + "' "
                          + "WHERE id=" + sifraKorisnika;
                
                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                konekcija.Open();
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


        public int IzmenaDodatihPodatakaKorisnika(int sifraKorisnika, string imeRoditelja, int? sifraMestaRodjenja, int? sifraOpstineRodjenja, string beleska, DateTime? datumRodjenja)
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            try
            {
                string sqlUpdateKorisnika = "UPDATE korisnik SET imeRoditelja='" + imeRoditelja + "', " +
                            "sifraMestaRodjenja='" + sifraMestaRodjenja + "', sifraOpstineRodjenja='" + sifraOpstineRodjenja + "', beleska='" + beleska + "', datumRodjenja='" + datumRodjenja + "'" +
                            " WHERE id=" + sifraKorisnika;

                SqlCommand komanda = new SqlCommand(sqlUpdateKorisnika, konekcija);
                konekcija.Open();
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