using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class KontaktTelefon
    {
        protected int sifraTelefona;
        protected string brojTelefona;
        protected int sifraKorisnika;

        public KontaktTelefon(int sifraTelefona, string brojTelefona, int sifraKorisnika)
        {
            this.sifraTelefona = sifraTelefona;
            this.brojTelefona = brojTelefona;
            this.sifraKorisnika = sifraKorisnika;
        }

        public KontaktTelefon() { }

        public int SifraTelefona
        {
            get{return sifraTelefona;}
            set{sifraTelefona = value;}
        }

        public string BrojTelefona
        {
            get{return brojTelefona;}
            set{brojTelefona = value;}
        }

        public int SifraKorisnika
        {
            get{return sifraKorisnika;}
            set{sifraKorisnika = value;}
        }

        public static List<KontaktTelefon> VratiSveKontaktTelefone(int sifraKorisnika)
        {
            string sqlUpit = "SELECT * " +
                             "FROM kontaktTelefon" +
                             "WHERE sifraKorisnika='" + sifraKorisnika + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            List<KontaktTelefon> listaKontaktTelefona = new List<KontaktTelefon>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    listaKontaktTelefona.Add(new KontaktTelefon(Convert.ToInt32(reader["sifraTelefona"]),
                       Convert.ToString(reader["brojTelefona"]), Convert.ToInt32(reader["sifraKorisnika"])));
                }
            }
            reader.Close();
            konekcija.Close();
            return listaKontaktTelefona;
        }
    }
}