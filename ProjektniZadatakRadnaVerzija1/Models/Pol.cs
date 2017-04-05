using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class Pol
    {
        private int sifraPola;
        private string nazivPola;

        public Pol(int sifraPola, string nazivPola)
        {
            this.sifraPola = sifraPola;
            this.nazivPola = nazivPola;
        }
        public Pol() { }

        public int SifraPola
        {
            get { return sifraPola; }
            set { sifraPola = value; }
        }

        public string NazivPola
        {
            get { return nazivPola; }
            set { nazivPola = value; }
        }
        public static Pol VratiPol(int sifraPola)
        {
            string sqlUpit = "SELECT * " +
                             "FROM pol " +
                             "WHERE sifraPola='" + sifraPola + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            Pol pol = new Pol();

            if (reader != null)
            {
                if (reader.Read())
                {
                    pol.sifraPola = Convert.ToInt32(reader["sifraPola"]);
                    pol.nazivPola = Convert.ToString(reader["nazivPola"]);
                }
            }
            reader.Close();
            konekcija.Close();

            return pol;
        }
        public static List<Pol> VratiPolove()
        {
            string sqlUpit = "SELECT * FROM pol ";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            List<Pol> listaPolova = new List<Pol>();

            if (reader != null)
            {

                while (reader.Read())
                {
                    listaPolova.Add(new Pol(Convert.ToInt32(reader["sifraPola"]),
                        Convert.ToString(reader["nazivPola"])));
                }
            }
            reader.Close();
            konekcija.Close();

            return listaPolova;
        }
    }
}