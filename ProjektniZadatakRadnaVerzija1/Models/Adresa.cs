using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class Adresa
    {
        private int sifraAdrese;
        private string nazivAdrese;
        private string broj;
        private int sifraTipaAdrese;
        private int sifraKorisnika;
        private int sifraGrada;
        private int sifraOpstine;

        public Adresa(int sifraAdrese, string nazivAdrese, string broj, int sifraTipaAdrese, int sifraKorisnika, int sifraGrada, int sifraOpstine)
        {
            this.sifraAdrese = sifraAdrese;
            this.nazivAdrese = nazivAdrese;
            this.broj = broj;
            this.sifraTipaAdrese = sifraTipaAdrese;
            this.sifraKorisnika = sifraKorisnika;
            this.sifraGrada = sifraGrada;
            this.sifraOpstine = sifraOpstine;
        }
        public Adresa()
        {
            this.sifraAdrese = 0;
            this.nazivAdrese = null;
            this.broj = null;
            this.sifraTipaAdrese = 0;
            this.sifraKorisnika = 0;
            this.sifraGrada =0;
            this.sifraOpstine = 0;
        }

        public int SifraAdrese
        {
            get { return sifraAdrese; }
            set { sifraAdrese = value; }
        }

        public string NazivAdrese
        {
            get { return nazivAdrese; }
            set { nazivAdrese = value; }
        }

        public string Broj
        {
            get { return broj; }
            set { broj = value; }
        }

        public int SifraTipaAdrese
        {
            get { return sifraTipaAdrese; }
            set { sifraTipaAdrese = value; }
        }

        public int SifraKorisnika
        {
            get { return sifraKorisnika; }
            set { sifraKorisnika = value; }
        }

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

        public static Adresa VratiAdresuKuca(int sifraKorisnika, int sifraTipaAdrese=1)
        {
          
            string sqlUpit = "SELECT * FROM adresa WHERE sifraKorisnika='" + sifraKorisnika + "' and sifraTipaAdrese='" + sifraTipaAdrese + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();
           
            Adresa adresa = null;

                if (reader != null)
                {
                    if (reader.Read())
                    {
                        adresa = new Adresa(Convert.ToInt32(reader["sifraAdrese"]),
                             Convert.ToString(reader["adresa"]), Convert.ToString(reader["broj"]),
                             Convert.ToInt32(reader["sifraTipaAdrese"]), Convert.ToInt32(reader["sifraKorisnika"]),
                             Convert.ToInt32(reader["sifraGrada"]), Convert.ToInt32(reader["sifraOpstine"]));
                    }
                }
                reader.Close();
                konekcija.Close();
       
            return adresa;
        }


        public static Adresa VratiAdresuPosao(int sifraKorisnika, int sifraTipaAdrese = 2)
        {

            string sqlUpit = "SELECT * FROM adresa WHERE sifraKorisnika='" + sifraKorisnika + "' and sifraTipaAdrese='" + sifraTipaAdrese + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            Adresa adresa = null;

            if (reader != null)
            {
                if (reader.Read())
                {
                    adresa = new Adresa(Convert.ToInt32(reader["sifraAdrese"]),
                         Convert.ToString(reader["adresa"]), Convert.ToString(reader["broj"]),
                         Convert.ToInt32(reader["sifraTipaAdrese"]), Convert.ToInt32(reader["sifraKorisnika"]),
                         Convert.ToInt32(reader["sifraGrada"]), Convert.ToInt32(reader["sifraOpstine"]));
                }
            }

            reader.Close();
            konekcija.Close();

            return adresa;
        }

        public static Adresa VratiAdresuLicnaKarta(int sifraKorisnika, int sifraTipaAdrese = 3)
        {

            string sqlUpit = "SELECT * FROM adresa WHERE sifraKorisnika='" + sifraKorisnika + "' and sifraTipaAdrese='" + sifraTipaAdrese + "'";

            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;

            konekcija.Open();
            SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
            reader = komanda.ExecuteReader();

            Adresa adresa = null;

            if (reader != null)
            {
                if (reader.Read())
                {
                    adresa = new Adresa(Convert.ToInt32(reader["sifraAdrese"]),
                         Convert.ToString(reader["adresa"]), Convert.ToString(reader["broj"]),
                         Convert.ToInt32(reader["sifraTipaAdrese"]), Convert.ToInt32(reader["sifraKorisnika"]),
                         Convert.ToInt32(reader["sifraGrada"]), Convert.ToInt32(reader["sifraOpstine"]));
                }
            }

            reader.Close();
            konekcija.Close();

            return adresa;
        }


    }
}