using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class LokalFiksni
    {
        private int sifraLokala;
        private string lokal;

        public LokalFiksni(int sifraLokala, string lokal)
        {
            this.sifraLokala = sifraLokala;
            this.lokal = lokal;
        }

        public LokalFiksni() { }

        public int SifraLokala
        {
            get{return sifraLokala;}
            set{sifraLokala = value;}
        }

        public string Lokal
        {
            get{return lokal;}
            set{lokal = value;}
        }

        public static LokalFiksni VratiLokalFiksni(int sifraLokala)
        {
            string sqlUpit = "SELECT * " +
                             "FROM lokalFiksni " +
                             "WHERE sifraLokala='" + sifraLokala + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            LokalFiksni lokalFiksni = new LokalFiksni();

            if (reader != null)
            {
                if (reader.Read())
                {
                    lokalFiksni.sifraLokala = Convert.ToInt32(reader["sifraLokala"]);
                    lokalFiksni.lokal = Convert.ToString(reader["lokal"]);
                }
            }
            reader.Close();
            konekcija.Close();

            return lokalFiksni;
        }

        public static List<LokalFiksni> VratiSveFiksneLokale()
        {
            string sqlUpit = "SELECT * FROM lokalFiksni";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            List<LokalFiksni> listaFiksnihLokala = new List<LokalFiksni>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    listaFiksnihLokala.Add(new LokalFiksni(Convert.ToInt32(reader["sifraLokala"]),
                       Convert.ToString(reader["lokal"])));
                }
            }
            reader.Close();
            konekcija.Close();

            return listaFiksnihLokala;
        }
    }
}