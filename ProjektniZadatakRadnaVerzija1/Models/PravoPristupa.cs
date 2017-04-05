using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class PravoPristupa
    {
        private int sifraPristupa;
        private string nazivPristupa;

        public PravoPristupa(int sifraPristupa, string nazivPristupa)
        {
            this.sifraPristupa = sifraPristupa;
            this.nazivPristupa = nazivPristupa;
        }

        public PravoPristupa(){}

        public int SifraPristupa
        {
            get{return sifraPristupa;}
            set{sifraPristupa = value;}
        }

        public string NazivPristupa
        {
            get{return nazivPristupa;}
            set { nazivPristupa = value;}
        }

        public static PravoPristupa VratiPravoPristupa(int sifraPristupa)
        {
            string sqlUpit = "SELECT * "+
                             "FROM pravoPristupa "+
                             "WHERE sifraPristupa='" + sifraPristupa + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            PravoPristupa pravoPristupa = new PravoPristupa();

            if(reader!=null)
            {
                if(reader.Read())
                {
                    pravoPristupa.nazivPristupa = Convert.ToString(reader["nazivPristupa"]);
                    pravoPristupa.sifraPristupa = Convert.ToInt32(reader["sifraPristupa"]);
                }
            }
            reader.Close();
            konekcija.Close();

            return pravoPristupa;
        }

        public static List<PravoPristupa> VratiSvaPravaPristupa()
        {
            string sqlUpit = "SELECT * " +
                             "FROM pravoPristupa ";


            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            List<PravoPristupa> listaPravaPristupa = new List<PravoPristupa>();
            
            if (reader != null)
            {

                while (reader.Read())
                {
                    listaPravaPristupa.Add(new PravoPristupa(Convert.ToInt32(reader["sifraPristupa"]),
                        Convert.ToString(reader["nazivPristupa"])));

                }
            }
            reader.Close();
            konekcija.Close();

            return listaPravaPristupa;
        }
    }
}