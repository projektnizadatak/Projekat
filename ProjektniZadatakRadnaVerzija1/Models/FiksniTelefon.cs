using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class FiksniTelefon:KontaktTelefon
    {
        private int sifraLokala;
        private int sifraTipaFiksnog;

        public FiksniTelefon(int sifraLokala, int sifraTipaFiksnog, int sifraTelefona, string brojTelefona, int sifraKorisnika) : base(sifraTelefona, brojTelefona, sifraKorisnika)
        {
            this.sifraLokala = sifraLokala;
            this.sifraTipaFiksnog = sifraTipaFiksnog;
        }

        public FiksniTelefon() { }

        

        public int SifraLokala
        {
            get{return sifraLokala;}
            set{sifraLokala = value;}
        }

        public int SifraTipaFiksnog
        {
            get{return sifraTipaFiksnog;}
            set{sifraTipaFiksnog = value;}
        }

        public static FiksniTelefon VratiPosaoFiksniTelefon(int sifraKorisnika, int sifraTipaFiksnog=3)
        {
            string sqlUpit = "SELECT ft.sifraLokala, ft.sifraTipaFiksnog, kt.sifraTelefona, kt.brojTelefona, kt.sifraKorisnika " +
                             "FROM fiksniTelefon ft " +
                             "JOIN kontaktTelefon kt on ft.sifraTelefona=kt.sifraTelefona " +
                             "WHERE kt.sifraKorisnika='" + sifraKorisnika + "' and sifraTipaFiksnog='"+ sifraTipaFiksnog + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            FiksniTelefon fiksniTelefon = null;

            if (reader != null)
            {
                while (reader.Read())
                {
                    fiksniTelefon=new FiksniTelefon(Convert.ToInt32(reader["sifraLokala"]),
                        Convert.ToInt32(reader["sifraTipaFiksnog"]), Convert.ToInt32(reader["sifraTelefona"]),
                        Convert.ToString(reader["brojTelefona"]), Convert.ToInt32(reader["sifraKorisnika"]));
                }
            }
            reader.Close();

            konekcija.Close();

            return fiksniTelefon;
        }



        public static FiksniTelefon VratiKucaFiksniTelefon(int sifraKorisnika, int sifraTipaFiksnog = 6)
        {
            string sqlUpit = "SELECT ft.sifraLokala, ft.sifraTipaFiksnog, kt.sifraTelefona, kt.brojTelefona, kt.sifraKorisnika " +
                             "FROM fiksniTelefon ft " +
                             "JOIN kontaktTelefon kt on ft.sifraTelefona=kt.sifraTelefona " +
                             "WHERE kt.sifraKorisnika='" + sifraKorisnika + "' and sifraTipaFiksnog='" + sifraTipaFiksnog + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            FiksniTelefon fiksniTelefon = null;

            if (reader != null)
            {
                while (reader.Read())
                {
                    fiksniTelefon = new FiksniTelefon(Convert.ToInt32(reader["sifraLokala"]),
                        Convert.ToInt32(reader["sifraTipaFiksnog"]), Convert.ToInt32(reader["sifraTelefona"]),
                        Convert.ToString(reader["brojTelefona"]), Convert.ToInt32(reader["sifraKorisnika"]));
                }
            }
            reader.Close();

            konekcija.Close();

            return fiksniTelefon;
        }

    }
}