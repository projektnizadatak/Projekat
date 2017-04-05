using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class Korisnik
    {

        private int id;
        private string korisnickoIme;
        private string lozinka;
        private int sifraPravaPristupa;
        private string ime;
        private string prezime;
        private string imeRoditelja;
        private string jmbg;
        private string brojLicneKarte;
        private DateTime? datumRodjenja;
        private int sifraMestaRodjenja;
        private int sifraOpstineRodjenja;
        private int sifraPola;
        private string fotografija;
        private string beleska;
       

        public Korisnik(int id, string korisnickoIme, string lozinka, int sifraPravaPristupa, string ime, string prezime, string imeRoditelja, string jmbg, string brojLicneKarte, DateTime datumRodjenja, int sifraMestaRodjenja, int sifraOpstineRodjenja, int sifraPola, string fotografija, string beleska)
        {
            this.id = id;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.sifraPravaPristupa = sifraPravaPristupa;
            this.ime = ime;
            this.prezime = prezime;
            this.imeRoditelja = imeRoditelja;
            this.jmbg = jmbg;
            this.brojLicneKarte = brojLicneKarte;
            this.datumRodjenja = datumRodjenja;
            this.sifraMestaRodjenja = sifraMestaRodjenja;
            this.sifraOpstineRodjenja = sifraOpstineRodjenja;
            this.sifraPola = sifraPola;
            this.fotografija = fotografija;
            this.beleska = beleska;
           
        }
        public Korisnik() 
        {
            this.id = 0;
            this.korisnickoIme = null;
            this.lozinka = null;
            this.sifraPravaPristupa = 0;
            this.ime = null;
            this.prezime = null;
            this.imeRoditelja = null;
            this.jmbg = null;
            this.brojLicneKarte = null;
            this.datumRodjenja= null;
            this.sifraMestaRodjenja = 0;
            this.sifraOpstineRodjenja = 0;
            this.sifraPola = 0;
            this.fotografija = null;
            this.beleska = null;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; }
        }

        public string Lozinka
        {
            get { return lozinka; }
            set { lozinka = value; }
        }

        public int SifraPravaPristupa
        {
            get { return sifraPravaPristupa; }
            set { sifraPravaPristupa = value; }
        }

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        public string ImeRoditelja
        {
            get { return imeRoditelja; }
            set { imeRoditelja = value; }
        }

        public string Jmbg
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        public string BrojLicneKarte
        {
            get { return brojLicneKarte; }
            set { brojLicneKarte = value; }
        }

        public DateTime? DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }

        public int SifraMestaRodjenja
        {
            get { return sifraMestaRodjenja; }
            set { sifraMestaRodjenja = value; }
        }

        public int SifraOpstineRodjenja
        {
            get { return sifraOpstineRodjenja; }
            set { sifraOpstineRodjenja = value; }
        }

        public int SifraPola
        {
            get { return sifraPola; }
            set { sifraPola = value; }
        }

        public string Fotografija
        {
            get { return fotografija; }
            set { fotografija = value; }
        }

        public string Beleska
        {
            get { return beleska; }
            set { beleska = value; }
        }


        public static List<Korisnik> VratiSveKorisnike()
        {
            string sqlUpit = "SELECT * FROM korisnik order by ime";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            List<Korisnik> listaSvihKorisnika = new List<Korisnik>();

            if (reader != null)
            {

                while (reader.Read())
                {

                    Korisnik korisnik = new Korisnik();
                    korisnik.Id = Convert.ToInt32(reader["id"]);
                    korisnik.KorisnickoIme = Convert.ToString(reader["korisnickoIme"]);
                    korisnik.Lozinka = Convert.ToString(reader["lozinka"]);
                    korisnik.Ime = Convert.ToString(reader["ime"]);
                    korisnik.Prezime = Convert.ToString(reader["prezime"]);
                    korisnik.Jmbg = Convert.ToString(reader["jmbg"]);
                    korisnik.BrojLicneKarte = Convert.ToString(reader["brojLicneKarte"]);
                    korisnik.SifraPola = Convert.ToInt32(reader["sifraPola"]);
                    korisnik.SifraPravaPristupa = Convert.ToInt32(reader["sifraPravaPristupa"]);

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

                    listaSvihKorisnika.Add(korisnik);
                }
            }
            reader.Close();
            konekcija.Close();

            return listaSvihKorisnika;
        }

        public static Korisnik VratiKorisnika(int idKorisnika)
        {
            string sqlUpit = "SELECT * FROM korisnik where id='" + idKorisnika + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            Korisnik korisnik = new Korisnik();

            if (reader != null)
            {

                if (reader.Read())
                {
                    korisnik.Id = Convert.ToInt32(reader["id"]);
                    korisnik.KorisnickoIme = Convert.ToString(reader["korisnickoIme"]);
                    korisnik.Lozinka = Convert.ToString(reader["lozinka"]);
                    korisnik.Ime = Convert.ToString(reader["ime"]);
                    korisnik.Prezime = Convert.ToString(reader["prezime"]);
                    korisnik.Jmbg = Convert.ToString(reader["jmbg"]);
                    korisnik.BrojLicneKarte = Convert.ToString(reader["brojLicneKarte"]);
                    korisnik.SifraPola = Convert.ToInt32(reader["sifraPola"]);
                    korisnik.SifraPravaPristupa = Convert.ToInt32(reader["sifraPravaPristupa"]);

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
            }
            reader.Close();
            konekcija.Close();

            return korisnik;
        }
        
    }
}