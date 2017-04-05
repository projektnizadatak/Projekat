using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class BazaPodataka
    {

        public SqlConnection konekcija = null;
        SqlDataReader reader = null;

        public SqlDataReader CitanjePodatakaIzBaze(string sqlUpit)
        {

            try
            {

                konekcija = new SqlConnection(Konekcija.konekcioniString);
                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                konekcija.Open();
                reader = komanda.ExecuteReader();
                
                return reader;
              
            }
            catch(Exception)
            {
                return reader;
            }

            
         }

        public bool AzuriranjePodatakaUBazi(string sqlUpit)
        {

            bool izvrsenUpit=false;

            try
            {

                konekcija = new SqlConnection(Konekcija.konekcioniString);
                SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                konekcija.Open();
                komanda.ExecuteNonQuery();
                izvrsenUpit = true;
                return izvrsenUpit;
            }
            catch (Exception)
            {
                return izvrsenUpit;
            }

        }

        public void ZatvoriKonekciju()
        {
            
        }


    }
}