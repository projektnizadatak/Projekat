using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class LokalMobilni
    {
        private int sifraLokala;
        private string lokal;

        public LokalMobilni(int sifraLokala, string lokal)
        {
            this.sifraLokala = sifraLokala;
            this.lokal = lokal;
        }

        public LokalMobilni() { }

        public int SifraLokala
        {
            get { return sifraLokala; }
            set { sifraLokala = value; }
        }

        public string Lokal
        {
            get { return lokal; }
            set { lokal = value; }
        }

        public static LokalMobilni VratiLokalMobilni(int sifraLokala)
        {
            string sqlUpit = "SELECT * " +
                             "FROM lokalMobilni " +
                             "WHERE sifraLokala='" + sifraLokala + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            LokalMobilni lokalMobilni = new LokalMobilni();

            if (reader != null)
            {
                if (reader.Read())
                {
                    lokalMobilni.sifraLokala = Convert.ToInt32(reader["sifraLokala"]);
                    lokalMobilni.lokal = Convert.ToString(reader["lokal"]);
                }
            }
            reader.Close();
            konekcija.Close();

            return lokalMobilni;
        }

        public static List<LokalMobilni> VratiSveMobilneLokale()
        {
            string sqlUpit = "SELECT * FROM lokalMobilni";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            List<LokalMobilni> listaMobilnihLokala = new List<LokalMobilni>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    listaMobilnihLokala.Add(new LokalMobilni(Convert.ToInt32(reader["sifraLokala"]),
                       Convert.ToString(reader["lokal"])));
                }
            }
            reader.Close();
            konekcija.Close();
            
            return listaMobilnihLokala;
        }
    }
}