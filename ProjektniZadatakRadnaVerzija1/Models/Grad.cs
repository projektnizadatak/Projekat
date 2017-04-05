using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class Grad
    {
        private int sifraGrada;
        private string nazivGrada;

        public Grad(int sifraGrada, string nazivGrada)
        {
            this.sifraGrada = sifraGrada;
            this.nazivGrada = nazivGrada;
        }
        public Grad() { }

        public int SifraGrada
        {
            get { return sifraGrada; }
            set { sifraGrada = value; }
        }

        public string NazivGrada
        {
            get { return nazivGrada; }
            set { nazivGrada = value; }
        }

        public static Grad VratiGrad(int sifraGrada)
        {
            string sqlUpit = "SELECT * " +
                             "FROM grad " +
                             "WHERE sifraGrada='" + sifraGrada + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            Grad grad = new Grad();

            if (reader != null)
            {
                if (reader.Read())
                {
                    grad.nazivGrada = Convert.ToString(reader["nazivGrada"]);
                    grad.sifraGrada = Convert.ToInt32(reader["sifraGrada"]);
                }
            }
            reader.Close();
            konekcija.Close();
            return grad;
        }
        public static List<Grad> VratiSveGradove()
        {
            string sqlUpit = "SELECT * FROM grad ";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            List<Grad> listaSvihGradova = new List<Grad>();

            if (reader != null)
            {

                while (reader.Read())
                {
                    listaSvihGradova.Add(new Grad(Convert.ToInt32(reader["sifraGrada"]),
                        Convert.ToString(reader["nazivGrada"])));
                }
            }
            reader.Close();
            konekcija.Close();
            return listaSvihGradova;
        }
    }
}