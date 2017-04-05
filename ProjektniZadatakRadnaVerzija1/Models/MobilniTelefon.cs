using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class MobilniTelefon:KontaktTelefon
    {
        private int sifraLokala;
        private int sifraTipaMobilnog;
        
        public MobilniTelefon(int sifraLokala, int sifraTipaMobilnog, int sifraTelefona, string brojTelefona, int sifraKorisnika):base(sifraTelefona, brojTelefona, sifraKorisnika)
        {
            this.sifraLokala = sifraLokala;
            this.sifraTipaMobilnog = sifraTipaMobilnog;
            
        }

        public MobilniTelefon() { }

        public int SifraLokala
        {
            get { return sifraLokala; }
            set { sifraLokala = value; }
        }

        public int SifraTipaMobilnog
        {
            get { return sifraTipaMobilnog; }
            set { sifraTipaMobilnog = value; }
        }

        public static MobilniTelefon VratiPrivatniMobilniTelefon(int sifraKorisnika, int sifraTipaMobilnog=1)
        {
            string sqlUpit = "SELECT mt.sifraLokala, mt.sifraTipaMobilnog, kt.sifraTelefona, kt.brojTelefona, kt.sifraKorisnika " +
                             "FROM mobilniTelefon mt " +
                             "JOIN kontaktTelefon kt on mt.sifraTelefona=kt.sifraTelefona " +
                             "WHERE kt.sifraKorisnika='" + sifraKorisnika + "' and mt.sifraTipaMobilnog='"+ sifraTipaMobilnog + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            MobilniTelefon mobilniTelefon = null;

            if (reader != null)
            {
                while (reader.Read())
                {
                    mobilniTelefon=new MobilniTelefon(Convert.ToInt32(reader["sifraLokala"]),
                        Convert.ToInt32(reader["sifraTipaMobilnog"]), Convert.ToInt32(reader["sifraTelefona"]),
                        Convert.ToString(reader["brojTelefona"]), Convert.ToInt32(reader["sifraKorisnika"]));
                       
                }
            }
            reader.Close();
            konekcija.Close();
           
            return mobilniTelefon;
        }


        public static MobilniTelefon VratiSluzbeniMobilniTelefon(int sifraKorisnika, int sifraTipaMobilnog = 2)
        {
            string sqlUpit = "SELECT mt.sifraLokala, mt.sifraTipaMobilnog, kt.sifraTelefona, kt.brojTelefona, kt.sifraKorisnika " +
                             "FROM mobilniTelefon mt " +
                             "JOIN kontaktTelefon kt on mt.sifraTelefona=kt.sifraTelefona " +
                             "WHERE kt.sifraKorisnika='" + sifraKorisnika + "' and mt.sifraTipaMobilnog='" + sifraTipaMobilnog + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            MobilniTelefon mobilniTelefon = null;

            if (reader != null)
            {
                while (reader.Read())
                {
                    mobilniTelefon = new MobilniTelefon(Convert.ToInt32(reader["sifraLokala"]),
                        Convert.ToInt32(reader["sifraTipaMobilnog"]), Convert.ToInt32(reader["sifraTelefona"]),
                        Convert.ToString(reader["brojTelefona"]), Convert.ToInt32(reader["sifraKorisnika"]));

                }
            }
            reader.Close();
            konekcija.Close();

            return mobilniTelefon;
        }


       


    }
}