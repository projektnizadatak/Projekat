using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class TipEmailAdrese
    {
        private int sifraTipa;
        private string nazivTipa;

        public TipEmailAdrese(int sifraTipa, string nazivTipa)
        {
            this.sifraTipa = sifraTipa;
            this.nazivTipa = nazivTipa;
        }
        public TipEmailAdrese() { }

        public int SifraTipa
        {
            get { return sifraTipa; }
            set { sifraTipa = value; }
        }

        public string NazivTipa
        {
            get { return nazivTipa; }
            set { nazivTipa = value; }
        }
       
    }
}