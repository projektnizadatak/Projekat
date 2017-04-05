using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ProjektniZadatakRadnaVerzija1.Models
{
    public class Konekcija
    {
        public static string konekcioniString = ConfigurationManager.ConnectionStrings["Konekcija"].ConnectionString;
    }
}