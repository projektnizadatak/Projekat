using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.SqlClient;
using ProjektniZadatakRadnaVerzija1.Models;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class IzmenaKorisnikaController : Controller
    {
        // GET: IzmenaKorisnika
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult IzmenaKorisnikaUBazu()
        {
            int sifraKorisnika = Convert.ToInt32(Request.Form["sifraKorisnika"]);
            int sifraPristupa = Convert.ToInt32(Request.Form["pravoPristupa"]);
            string korisnickoIme = Request.Form["korisnickoIme"];
            string lozinka = Request.Form["lozinka"];
            string ime = Request.Form["ime"];
            string prezime = Request.Form["prezime"];
            int sifraPola = Convert.ToInt32(Request.Form["pol"]);
            string jmbg = Request.Form["jmbg"];
            string brojLicneKarte = Request.Form["brojLicneKarte"];
            string imeRoditelja = Request.Form["imeRoditelja"];
            DateTime datumRodjenja = Convert.ToDateTime(Request.Form["datumRodjenja"]);
            int mestoRodjenja = Convert.ToInt32(Request.Form["mestoRodjenja"]);
            int opstinaRodjenja = Convert.ToInt32(Request.Form["opstinaRodjenja"]);
            string[] indeksNiza = Request.Form.GetValues("indeksNiza[]");
            string[] sifraTipaAdrese = Request.Form.GetValues("sifraTipaAdrese[]");
            string[] adresa = Request.Form.GetValues("adresa[]");
            string[] broj = Request.Form.GetValues("broj[]");
            string[] grad = Request.Form.GetValues("grad[]");
            string[] opstina = Request.Form.GetValues("opstina[]");
            bool[] popunjeniPodaciKorisnika = { false, false, false, false, false, false };
            string beleska = Request.Form["beleska"];
            BazaPodataka bazaPodataka = new BazaPodataka();

            try
            {
                if (!String.IsNullOrEmpty(korisnickoIme) && !String.IsNullOrEmpty(lozinka) && sifraPristupa > 0 && !String.IsNullOrEmpty(ime) && !String.IsNullOrEmpty(prezime) &&
                    !String.IsNullOrEmpty(jmbg) && !String.IsNullOrEmpty(brojLicneKarte) && sifraPola > 0 && !String.IsNullOrEmpty(imeRoditelja) && datumRodjenja != null
                    && mestoRodjenja > 0 && opstinaRodjenja > 0 && !String.IsNullOrEmpty(beleska))
                {


                    string sqlUpit = "UPDATE korisnik SET"
                   + " korisnickoIme='" + korisnickoIme + "',"
                   + "sifraPravaPristupa='" + sifraPristupa + "',"
                   + "ime='" + ime + "',"
                   + "prezime='" + prezime + "',"
                   + "jmbg='" + jmbg + "',"
                   + "brojLicneKarte='" + brojLicneKarte + "',"
                   + "sifraPola='" + sifraPola + "',"
                   + "imeRoditelja='" + imeRoditelja + "',"
                   + "sifraMestaRodjenja='" + mestoRodjenja + "',"
                   + "sifraOpstineRodjenja='" + opstinaRodjenja + "',"
                   + "beleska='" + beleska + "',"
                   + "datumRodjenja='" + datumRodjenja + "'"
                   + " WHERE id=" + sifraKorisnika;


                    bool izvrsenUpdate;
                    izvrsenUpdate = bazaPodataka.AzuriranjePodatakaUBazi(sqlUpit);

                    if (!izvrsenUpdate)
                    {
                        string poruka = "UPDATE korisnik SET je failovao:";
                        Session["greska"] = poruka;
                        return RedirectToAction("Index", "Greska");
                    }
                }

            }
            catch (Exception)
            {
                string poruka = "UPDATE korisnik SET je failovao IzmenaKorisnikaController";
                Session["greska"] = poruka;
                return RedirectToAction("Index", "Greska");

            }
            finally
            {
                bazaPodataka.ZatvoriKonekciju();
            }

            try
            {
                if (indeksNiza != null && indeksNiza.Length > 0)
                {

                    if (sifraTipaAdrese != null && adresa != null && broj != null && grad != null && opstina != null)
                    {
                        int brojacAdresa = 0;

                        foreach (string s in indeksNiza)
                        {
                            int indeks = Convert.ToInt32(s);

                            if (!String.IsNullOrEmpty(sifraTipaAdrese[indeks]) && !String.IsNullOrEmpty(adresa[indeks]) && !String.IsNullOrEmpty(broj[indeks]) && !String.IsNullOrEmpty(grad[indeks]) && !String.IsNullOrEmpty(opstina[indeks]))
                            {
                                brojacAdresa++;
                            }
                        }

                        if (brojacAdresa == indeksNiza.Length)
                        {
                            foreach (string s in indeksNiza)
                            {
                                int indeks = Convert.ToInt32(s);

                                string sqlUpit = "UPDATE adresa SET "
                               + "adresa='" + adresa[indeks] + "',"
                               + "broj='" + broj[indeks] + "',"
                               + "sifraKorisnika='" + sifraKorisnika + "',"
                               + "sifraGrada='" + Convert.ToInt32(grad[indeks]) + "',"
                               + "sifraOpstine='" + Convert.ToInt32(opstina[indeks]) + "'"
                               + " WHERE sifraKorisnika='" + sifraKorisnika + "'"
                               + " AND sifraTipaAdrese='" + Convert.ToInt32(sifraTipaAdrese[indeks]) + "'";

                                bool izvrsenUpdate;
                                izvrsenUpdate = bazaPodataka.AzuriranjePodatakaUBazi(sqlUpit);

                                if (!izvrsenUpdate)
                                {
                                    string poruka = "UPDATE adresa SET je failovao";
                                    Session["greska"] = poruka;
                                    return RedirectToAction("Index", "Greska");
                                }

                            }
                        }
                        else
                        {
                            string poruka = "Greska brojaca adresa pri unosu";
                            Session["greska"] = poruka;
                            return RedirectToAction("Index", "Greska");
                        }
                    }
                }

            }
            catch (Exception)
            {
                string poruka = "UPDATE adresa SET je failovao IzmenaKorisnikaController";
                Session["greska"] = poruka;
                return RedirectToAction("Index", "Greska");

            }
            finally
            {
                bazaPodataka.ZatvoriKonekciju();
            }

            string[] indeksNizaEmail = Request.Form.GetValues("indeksNizaEmail[]");
            string[] emailAdresa = Request.Form.GetValues("email[]");
            string[] sifraTipaEmailAdrese = Request.Form.GetValues("sifraTipaEmailAdrese[]");

            if (indeksNizaEmail != null && indeksNizaEmail.Length > 0)
            {
                try
                {
                    if (sifraTipaEmailAdrese != null && emailAdresa != null)
                    {
                        int brojacEmailAdresa = 0;

                        foreach (string s in indeksNizaEmail)
                        {
                            int indeks = Convert.ToInt32(s);

                            if (!String.IsNullOrEmpty(sifraTipaEmailAdrese[indeks]) && !String.IsNullOrEmpty(emailAdresa[indeks]))
                            {
                                brojacEmailAdresa++;
                            }
                        }

                        if (brojacEmailAdresa == indeksNizaEmail.Length)
                        {
                            foreach (string s in indeksNizaEmail)
                            {
                                int indeks = Convert.ToInt32(s);

                                string sqlUpit = "UPDATE emailAdresa SET "
                                + "email='" + emailAdresa[indeks] + "'"
                                + " WHERE sifraKorisnika='" + sifraKorisnika + "'"
                                + " AND sifraTipaEmail='" + Convert.ToInt32(sifraTipaEmailAdrese[indeks]) + "'";

                                bool izvrsenUpdate;
                                izvrsenUpdate = bazaPodataka.AzuriranjePodatakaUBazi(sqlUpit);

                                if (!izvrsenUpdate)
                                {
                                    string poruka = "UPDATE emailAdresa SET je failova";
                                    Session["greska"] = poruka;
                                    return RedirectToAction("Index", "Greska");
                                }

                            }
                        }
                        else
                        {
                            string poruka = "Greska brojaca email adrese pri unosu";
                            Session["greska"] = poruka;
                            return RedirectToAction("Index", "Greska");
                        }
                    }
                }

                catch (Exception)
                {
                    string poruka = "UPDATE emailAdrese SET je failovao IzmenaKorisnikaController";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");

                }
                finally
                {
                    bazaPodataka.ZatvoriKonekciju();
                }


                if (sifraTipaEmailAdrese != null && emailAdresa != null)
                {
                    try
                    {
                        int brojacEmailAdresa = 0;

                        foreach (string s in indeksNizaEmail)
                        {
                            int indeks = Convert.ToInt32(s);

                            if (!String.IsNullOrEmpty(sifraTipaEmailAdrese[indeks]) && !String.IsNullOrEmpty(emailAdresa[indeks]))
                            {
                                brojacEmailAdresa++;
                            }
                        }

                        if (brojacEmailAdresa == indeksNizaEmail.Length)
                        {
                            foreach (string s in indeksNizaEmail)
                            {
                                int indeks = Convert.ToInt32(s);

                                string sqlUpit = "UPDATE emailAdresa SET "
                                + "email='" + emailAdresa[indeks] + "'"
                                + " WHERE sifraKorisnika='" + sifraKorisnika + "'"
                                + " AND sifraTipaEmail='" + Convert.ToInt32(sifraTipaEmailAdrese[indeks]) + "'";

                                bool izvrsenUpdate;
                                izvrsenUpdate = bazaPodataka.AzuriranjePodatakaUBazi(sqlUpit);

                                if (!izvrsenUpdate)
                                {
                                    string poruka = "UPDATE emailAdresa SET je failova";
                                    Session["greska"] = poruka;
                                    return RedirectToAction("Index", "Greska");
                                }

                            }
                        }
                        else
                        {
                            string poruka = "Greska brojaca email adrese pri unosu";
                            Session["greska"] = poruka;
                            return RedirectToAction("Index", "Greska");
                        }
                    }
                    catch (Exception)
                    {
                        string poruka = "UPDATE korisnik SET je failovao IzmenaKorisnikaController";
                        Session["greska"] = poruka;
                        return RedirectToAction("Index", "Greska");

                    }
                    finally
                    {
                        bazaPodataka.ZatvoriKonekciju();
                    }

                }
            }


            string[] indeksNizaMobilnog = Request.Form.GetValues("indeksNizaMobilnog[]");
            string[] mobilni = Request.Form.GetValues("mobilni[]");
            string[] sifraTipaMobilnog = Request.Form.GetValues("sifraTipaMobilnog[]");
            string[] lokalMobilni = Request.Form.GetValues("lokalMobilni[]");
            string[] sifraTelefona = Request.Form.GetValues("sifraTelefona[]");

            try
            {
                if (indeksNizaMobilnog != null && indeksNizaMobilnog.Length > 0)
                {

                    if (sifraTipaMobilnog != null && mobilni != null && lokalMobilni != null)
                    {
                        int brojacMobilnog = 0;

                        foreach (string s in indeksNizaMobilnog)
                        {
                            int indeks = Convert.ToInt32(s);

                            if (!String.IsNullOrEmpty(sifraTipaMobilnog[indeks]) && !String.IsNullOrEmpty(mobilni[indeks]) && !String.IsNullOrEmpty(lokalMobilni[indeks]))
                            {
                                brojacMobilnog++;
                            }
                        }

                        if (brojacMobilnog == indeksNizaMobilnog.Length)
                        {
                            foreach (string s in indeksNizaMobilnog)
                            {
                                int indeks = Convert.ToInt32(s);

                                string sqlUpit = "UPDATE kontaktTelefon SET "
                                + "brojTelefona='" + mobilni[indeks] + "'"
                                + " WHERE sifraKorisnika='" + sifraKorisnika + "'"
                                + " AND sifraTelefona='" + Convert.ToInt32(sifraTelefona[indeks]) + "'";

                                bool izvrsenUpdateTelefon;
                                bool izvrsenUpdateMobilni;

                                izvrsenUpdateTelefon = bazaPodataka.AzuriranjePodatakaUBazi(sqlUpit);

                                string sqlUpdateMobilni = "UPDATE mobilniTelefon SET "
                              + "sifraLokala='" + Convert.ToInt32(lokalMobilni[indeks]) + "'"
                              + " WHERE sifraTelefona='" + Convert.ToInt32(sifraTelefona[indeks]) + "'";

                                izvrsenUpdateMobilni = bazaPodataka.AzuriranjePodatakaUBazi(sqlUpdateMobilni);


                                if (!izvrsenUpdateTelefon && !izvrsenUpdateMobilni)
                                {
                                    string poruka = "UPDATE mobilnog telefona nije uspeo nije uspesno izvrsen";
                                    Session["greska"] = poruka;
                                    return RedirectToAction("Index", "Greska");
                                }

                            }
                        }
                        else
                        {
                            string poruka = "Greska brojaca mobilnog pri unosu";
                            Session["greska"] = poruka;
                            return RedirectToAction("Index", "Greska");
                        }
                    }
                }
            }
            catch (Exception)
            {
                string poruka = "UPDATE mobilniTelefon SET je failovao IzmenaKorisnikaController";
                Session["greska"] = poruka;
                return RedirectToAction("Index", "Greska");

            }
            finally
            {
                bazaPodataka.ZatvoriKonekciju();
            }

            string[] indeksNizaFiksnog = Request.Form.GetValues("indeksNizaFiksnog[]");
            string[] fiksni = Request.Form.GetValues("fiksni[]");
            string[] sifraTipaFiksnog = Request.Form.GetValues("sifraTipaFiksnog[]");
            string[] lokalFiksni = Request.Form.GetValues("lokalFiksni[]");

            try {
                if (indeksNizaFiksnog != null && indeksNizaFiksnog.Length > 0)
                {

                    if (sifraTipaFiksnog != null && fiksni != null && lokalFiksni != null)
                    {
                        int brojacFiksni = 0;

                        foreach (string s in indeksNizaFiksnog)
                        {
                            int indeks = Convert.ToInt32(s);

                            if (!String.IsNullOrEmpty(sifraTipaFiksnog[indeks]) && !String.IsNullOrEmpty(fiksni[indeks]) && !String.IsNullOrEmpty(lokalFiksni[indeks]))
                            {
                                brojacFiksni++;
                            }
                        }

                        if (brojacFiksni == indeksNizaFiksnog.Length)
                        {
                            foreach (string s in indeksNizaFiksnog)
                            {
                                int indeks = Convert.ToInt32(s);

                                string sqlUpit = "UPDATE kontaktTelefon SET "
                                      + "brojTelefona='" + mobilni[indeks] + "'"
                                      + " WHERE sifraKorisnika='" + sifraKorisnika + "'"
                                      + " AND sifraTelefona='" + Convert.ToInt32(sifraTelefona[indeks]) + "'";

                                bool izvrsenUpdateTelefon;
                                bool izvrsenUpdateFiksni;

                                izvrsenUpdateTelefon = bazaPodataka.AzuriranjePodatakaUBazi(sqlUpit);

                                string sqlUpdateFiksni = "UPDATE fiksniTelefon SET "
                                + "sifraLokala='" + Convert.ToInt32(lokalFiksni[indeks]) + "'"
                                 + " WHERE sifraTelefona='" + Convert.ToInt32(sifraTelefona[indeks]) + "'";

                                izvrsenUpdateFiksni = bazaPodataka.AzuriranjePodatakaUBazi(sqlUpdateFiksni);

                                if (!izvrsenUpdateTelefon && !izvrsenUpdateFiksni)
                                {
                                    string poruka = "UPDATE mobilnog telefona nije uspeo nije uspesno izvrsen";
                                    Session["greska"] = poruka;
                                    return RedirectToAction("Index", "Greska");
                                }

                            }
                        }
                        else
                        {
                            string poruka = "Greska brojaca email adrese pri unosu";
                            Session["greska"] = poruka;
                            return RedirectToAction("Index", "Greska");
                        }
                    }
                }

                var fotografija = Request.Files["slika"];

                if (fotografija != null && fotografija.ContentLength > 0)
                {
                    var folder = Server.MapPath("~/image");
                    var ekstenzija = Path.GetExtension(fotografija.FileName);
                    var fotografijaPutanja = Path.ChangeExtension(Guid.NewGuid().ToString(), ekstenzija);
                    var fotografijaPunaPutanja = Path.Combine(folder, fotografijaPutanja);
                    fotografija.SaveAs(fotografijaPunaPutanja);

                    string sqlFotografija = "UPDATE korisnik SET fotografija='" + fotografijaPunaPutanja + "'" +
                        "WHERE id=" + sifraKorisnika;

                    bool izvrsenUpdate = bazaPodataka.AzuriranjePodatakaUBazi(sqlFotografija);

                    if (!izvrsenUpdate)
                    {
                        string poruka = "UPDATE fotografije nije uspesno izvrsen";
                        Session["greska"] = poruka;
                        return RedirectToAction("Index", "Greska");
                    }

                    popunjeniPodaciKorisnika[5] = true;
                }

                return RedirectToAction("Index");




            }
            catch (Exception)
            {
                string poruka = "UPDATE fotografija SET je failovao IzmenaKorisnikaController";
                Session["greska"] = poruka;
                return RedirectToAction("Index", "Greska");

            }
            finally
            {
                bazaPodataka.ZatvoriKonekciju();
            }

        }



    }
}
