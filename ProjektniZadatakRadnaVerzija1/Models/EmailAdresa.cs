using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class EmailAdresa
    {
        private int sifraEmail;
        private string email;
        private int sifraTipaEmail;
        private int sifraKorisnika;

        public EmailAdresa(int sifraEmail, string email, int sifraTipaEmail, int sifraKorisnika)
        {
            this.sifraEmail = sifraEmail;
            this.email = email;
            this.sifraTipaEmail = sifraTipaEmail;
            this.sifraKorisnika = sifraKorisnika;
        }
        public EmailAdresa() { }

        public int SifraEmail
        {
            get { return sifraEmail; }
            set { sifraEmail = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int SifraTipaEmail
        {
            get { return sifraTipaEmail; }
            set { sifraTipaEmail = value; }
        }

        public int SifraKorisnika
        {
            get { return sifraKorisnika; }
            set { sifraKorisnika = value; }
        }

        public static EmailAdresa VratiPrivatnuEmailAdresu(int sifraKorisnika, int sifraTipaEmail=1)
        {
            
            string sqlUpit = "SELECT * FROM emailAdresa WHERE sifraKorisnika='" + sifraKorisnika + "' and sifraTipaEmail='"+sifraTipaEmail+"'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            EmailAdresa emailAdresa = null;

            if (reader != null)
            {
                while (reader.Read())
                {
                    emailAdresa =new EmailAdresa(Convert.ToInt32(reader["sifraEmail"]),
                        Convert.ToString(reader["email"]), Convert.ToInt32(reader["sifraTipaEmail"]),
                        Convert.ToInt32(reader["sifraKorisnika"]));
                }
            }
            reader.Close();

            konekcija.Close();

            return emailAdresa;
        }

        public static EmailAdresa VratiPosaoEmailAdresu(int sifraKorisnika, int sifraTipaEmail = 2)
        {

            string sqlUpit = "SELECT * FROM emailAdresa WHERE sifraKorisnika='" + sifraKorisnika + "' and sifraTipaEmail='" + sifraTipaEmail + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            EmailAdresa emailAdresa = null;

            if (reader != null)
            {
                while (reader.Read())
                {
                    emailAdresa = new EmailAdresa(Convert.ToInt32(reader["sifraEmail"]),
                        Convert.ToString(reader["email"]), Convert.ToInt32(reader["sifraTipaEmail"]),
                        Convert.ToInt32(reader["sifraKorisnika"]));
                }
            }
            reader.Close();

            konekcija.Close();

            return emailAdresa;
        }
    }
}