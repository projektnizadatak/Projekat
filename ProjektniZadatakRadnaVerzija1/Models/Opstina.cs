using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class Opstina
    {
        private int sifraGrada;
        private int sifraOpstine;
        private string nazivOpstine;

        public Opstina(int sifraGrada, int sifraOpstine, string nazivOpstine)
        {
            this.sifraGrada = sifraGrada;
            this.sifraOpstine = sifraOpstine;
            this.nazivOpstine = nazivOpstine;
        }
        public Opstina() { }

        public int SifraGrada
        {
            get { return sifraGrada; }
            set { sifraGrada = value; }
        }

        public int SifraOpstine
        {
            get { return sifraOpstine; }
            set { sifraOpstine = value; }
        }

        public string NazivOpstine
        {
            get { return nazivOpstine; }
            set { nazivOpstine = value; }
        }

        public static Opstina VratiOpstinu(int sifraGrada, int sifraOpstine)
        {
            string sqlUpit = "SELECT * " +
                             "FROM opstina " +
                             "WHERE sifraGrada='" + sifraGrada + "' and sifraOpstine='"+sifraOpstine+"'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            Opstina opstina = new Opstina();

            if (reader != null)
            {
                if (reader.Read())
                {
                    opstina.sifraOpstine = Convert.ToInt32(reader["sifraOpstine"]);
                    opstina.sifraGrada = Convert.ToInt32(reader["sifraGrada"]);
                    opstina.nazivOpstine = Convert.ToString(reader["nazivOpstine"]);
                }
            }
            reader.Close();
            konekcija.Close();

            return opstina;
        }
        public static List<Opstina> VratiSveOpstine(int sifraGrada)
        {
            string sqlUpit = "SELECT * FROM opstina WHERE sifraGrada='"+sifraGrada+"'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            List<Opstina> listaSvihOpstina = new List<Opstina>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    listaSvihOpstina.Add(new Opstina(Convert.ToInt32(reader["sifraGrada"]),
                        Convert.ToInt32(reader["sifraOpstine"]), Convert.ToString(reader["nazivOpstine"])));
                }
            }
            reader.Close();
            konekcija.Close();

            return listaSvihOpstina;
        }
    }
}