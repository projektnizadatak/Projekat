using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektniZadatakRadnaVerzija1.Models;
using System.Data.SqlClient;
using System.IO;

namespace ProjektniZadatakRadnaVerzija1.Controllers
{
    public class UnosKorisnikaController : Controller
    {
        // GET: UnosKorisnika
        public ActionResult Index()
        {
            return View();
        }
        /*
        Metoda za unos korisnika u bazu se poziva i prilikom unosa novog korisnika i prilikom izmene
        postojeceg iz razloga sto je dizajn promenjen u poslednjem momentu.
        */
        public ActionResult UnosKorisnikaUBazu()
        {
            string sifraKorisnika = Request.Form["sifraKorisnika"];
            string sifraPristupa = Request.Form["pravoPristupa"];
            string korisnickoIme = Request.Form["korisnickoIme"];
            string lozinka = Request.Form["lozinka"];
            string ime = Request.Form["ime"];
            string prezime = Request.Form["prezime"];
            string sifraPola = Request.Form["pol"];
            string jmbg = Request.Form["jmbg"];
            string brojLicneKarte = Request.Form["brojLicneKarte"];
            int sifraKorisnikaUBazi = 0;
            SqlConnection konekcija = new SqlConnection(Konekcija.konekcioniString);
            SqlDataReader reader = null;
            
            try
                {
                
                    /*Proverava se da li korisnik sa unetim korisnickim imenom vec postoji u bazi.
                    Ukoliko vec postoji prikazuje se odgovarajuca poruka i neomogucava se unos novog korisnika*/
                    if (!String.IsNullOrEmpty(korisnickoIme))
                    {

                        string sqlUpit = "SELECT korisnickoIme FROM korisnik WHERE korisnickoIme='" + korisnickoIme + "'";

                    konekcija.Open();
                    SqlCommand komanda = new SqlCommand(sqlUpit, konekcija);
                    reader = komanda.ExecuteReader();

                    if (reader != null)
                        {
                            if (reader.Read())
                            {
                                string poruka = "Korisnicko ime je zauzeto!";
                                Session["porukaKorisnickoIme"] = poruka;
                                return RedirectToAction("PocetnaAdmin", "Logovanje");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    string poruka = "//Preuzimaju se podaci sa forme";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");
                }

                finally
                {
                   
                    konekcija.Close();
                }

                try
                {
                //Ukoliko korisnik ne postoji vrsi se kreiranje novog korisnika sa osnovnim podacima
                
                if (!String.IsNullOrEmpty(sifraKorisnika) && Convert.ToInt32(sifraKorisnika) == 0)
                    {
                        if (!String.IsNullOrEmpty(sifraPristupa) && !String.IsNullOrEmpty(korisnickoIme) && !String.IsNullOrEmpty(lozinka)
                            && !String.IsNullOrEmpty(ime) && !String.IsNullOrEmpty(prezime) && !String.IsNullOrEmpty(sifraPola)
                            && !String.IsNullOrEmpty(jmbg) && !String.IsNullOrEmpty(brojLicneKarte))
                        {
                            KorisnikController korisnikKontroler = new KorisnikController();
                            sifraKorisnikaUBazi = korisnikKontroler.UnosOsnovnihPodatakaKorisnika(korisnickoIme, lozinka, Convert.ToInt32(sifraPristupa), ime, prezime, jmbg, brojLicneKarte, Convert.ToInt32(sifraPola));

                            if (sifraKorisnikaUBazi == -1)
                            {
                                Session["greska"] = "Nije uspesno korisnik upisan u bazu";
                                return RedirectToAction("Index", "Greska");
                            }

                        }
                    }
                    else
                    {
                    //Ukoliko korisnik postoji vrsi se update njegovih osnovnih podataka
                    if (!String.IsNullOrEmpty(lozinka) && !String.IsNullOrEmpty(sifraPristupa) && !String.IsNullOrEmpty(ime) && !String.IsNullOrEmpty(prezime)
                            && !String.IsNullOrEmpty(sifraPola) && !String.IsNullOrEmpty(jmbg) && !String.IsNullOrEmpty(brojLicneKarte))
                        {
                            KorisnikController korisnikKontroler = new KorisnikController();
                            int izvrsenUpdate = korisnikKontroler.IzmenaOsnovnihPodatakaKorisnika(Convert.ToInt32(sifraKorisnika), lozinka, Convert.ToInt32(sifraPristupa), ime, prezime, jmbg, brojLicneKarte, Convert.ToInt32(sifraPola));

                            if (izvrsenUpdate == -1)
                            {
                                Session["greska"] = "Nije uspesno promenjen  korisnik u bazi";
                                return RedirectToAction("Index", "Greska");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    string poruka = "Osnovni podaci nisu dobro uneti";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");

                }

            
                //Preuzimaju se podaci koji su dodatni i nisu obavezni prilikom unosa novog korisnika
                string imeRoditeljaForma = Request.Form["imeRoditelja"];
                DateTime datumRodjenjaForma = Convert.ToDateTime(Request.Form["datumRodjenja"]);
                string mestoRodjenjaForma = Request.Form["mestoRodjenja"];
                string opstinaRodjenjaForma = Request.Form["opstinaRodjenja"];
                string beleskaForma = Request.Form["beleska"];
                try
                {
                    /*Ukoliko korisnik postoji uzima se sifra sa forme, a ukoliko ne postoji uzima se sifra iz baze
                    prilikom kreiranja korisnika*/
                    if ((!String.IsNullOrEmpty(sifraKorisnika) && Convert.ToInt32(sifraKorisnika) != 0) || (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0))
                    {
                        string imeRoditelja = null;

                        if (!String.IsNullOrEmpty(imeRoditeljaForma))
                        {
                            imeRoditelja = imeRoditeljaForma;
                        }

                        DateTime? datumRodjenja = null;
                        if (datumRodjenjaForma != null)
                        {
                            datumRodjenja = datumRodjenjaForma;
                        }


                        int? sifraMestaRodjenja = null;
                        if (!String.IsNullOrEmpty(mestoRodjenjaForma) && Convert.ToInt32(mestoRodjenjaForma) != 0)
                        {
                            sifraMestaRodjenja = Convert.ToInt32(mestoRodjenjaForma);
                        }

                        int? sifraOpstineRodjenja = null;
                        if (!String.IsNullOrEmpty(opstinaRodjenjaForma) && Convert.ToInt32(opstinaRodjenjaForma) != 0)
                        {
                            sifraOpstineRodjenja = Convert.ToInt32(opstinaRodjenjaForma);
                        }

                        string beleska = null;

                        if (!String.IsNullOrEmpty(beleskaForma))
                        {
                            beleska = beleskaForma;
                        }

                        KorisnikController korisnikKontroler = new KorisnikController();
                        int izvrsenUpdate = 0;
                        if (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)
                        {
                            izvrsenUpdate = korisnikKontroler.IzmenaDodatihPodatakaKorisnika(sifraKorisnikaUBazi, imeRoditelja, sifraMestaRodjenja, sifraOpstineRodjenja, beleska, datumRodjenja);
                        }
                        else
                        {
                            izvrsenUpdate = korisnikKontroler.IzmenaDodatihPodatakaKorisnika(Convert.ToInt32(sifraKorisnika), imeRoditelja, sifraMestaRodjenja, sifraOpstineRodjenja, beleska, datumRodjenja);
                        }
                        if (izvrsenUpdate == -1)
                        {
                            Session["greska"] = "Nije uspesno izvrsena izmena dodadtnih podataka korisnika";
                            return RedirectToAction("Index", "Greska");
                        }
                    }
                }
                catch (Exception)
                {
                    string poruka = "Preuzimaju se podaci koji su dodatni i nisu obavezni prilikom unosa novog korisnika";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");
                }
                
                //Preuzimanje podataka sa forme koji su vezani za kucnu adresu
                string sifraAdreseKucaForma = Request.Form["sifraAdreseKuca"];
                string adresaKucaForma = Request.Form["adresaKuca"];
                string brojAdreseKucaForma = Request.Form["brojAdreseKuca"];
                string adresaKucaGradForma = Request.Form["adresaKucaGrad"];
                string adresaKucaOpstinaForma = Request.Form["adresaKucaOpstina"];
                try
                {
                    //Ukoliko adresa vec postoji vrsi se njen update
                    if (!String.IsNullOrEmpty(sifraAdreseKucaForma) && Convert.ToInt32(sifraAdreseKucaForma) != 0 && ((!String.IsNullOrEmpty(sifraKorisnika) && Convert.ToInt32(sifraKorisnika) != 0) || (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)))
                    {
                        string adresaKuca = null;
                        if (!String.IsNullOrEmpty(adresaKucaForma))
                        {
                            adresaKuca = adresaKucaForma;
                        }

                        string brojAdreseKuca = null;
                        if (!String.IsNullOrEmpty(brojAdreseKucaForma))
                        {
                            brojAdreseKuca = brojAdreseKucaForma;
                        }

                        int? sifraGradaAdresaKuca = null;
                        if (!String.IsNullOrEmpty(adresaKucaGradForma) && Convert.ToInt32(adresaKucaGradForma) != 0)
                        {
                            sifraGradaAdresaKuca = Convert.ToInt32(adresaKucaGradForma);
                        }

                        int? sifraOpstineAdresaKuca = null;
                        if (!String.IsNullOrEmpty(adresaKucaOpstinaForma) && Convert.ToInt32(adresaKucaOpstinaForma) != 0)
                        {
                            sifraOpstineAdresaKuca = Convert.ToInt32(adresaKucaOpstinaForma);
                        }

                        int izvrsenaIzmenaAdrese = AdresaController.IzmenaAdrese(Convert.ToInt32(sifraKorisnika), Convert.ToInt32(sifraAdreseKucaForma), adresaKuca, brojAdreseKuca, sifraGradaAdresaKuca, sifraOpstineAdresaKuca);

                        if (izvrsenaIzmenaAdrese == -1)
                        {
                            Session["greska"] = "Nije uspesno izvrsena izmena kucne adrese korisnika";
                            return RedirectToAction("Index", "Greska");
                        }

                    }
                    else
                    {
                        //Ukoliko adresa ne postoji, kreira se nova adresa u bazi
                        if (!String.IsNullOrEmpty(adresaKucaForma) && !String.IsNullOrEmpty(brojAdreseKucaForma) && !String.IsNullOrEmpty(adresaKucaGradForma) && !String.IsNullOrEmpty(adresaKucaOpstinaForma))
                        {
                            int izvrsenInsertAdrese = 0;

                            if (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)
                            {
                                izvrsenInsertAdrese = AdresaController.UnosAdreseKuca(sifraKorisnikaUBazi, adresaKucaForma, brojAdreseKucaForma, Convert.ToInt32(adresaKucaGradForma), Convert.ToInt32(adresaKucaOpstinaForma));
                            }
                            else
                            {
                                izvrsenInsertAdrese = AdresaController.UnosAdreseKuca(Convert.ToInt32(sifraKorisnika), adresaKucaForma, brojAdreseKucaForma, Convert.ToInt32(adresaKucaGradForma), Convert.ToInt32(adresaKucaOpstinaForma));
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    string poruka = "//Preuzimanje podataka sa forme koji su vezani za kucnu adresu";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");

                }


                //Preuzimanje podataka sa forme koji su vezani za poslovnu adresu

                string sifraAdresePosaoForma = Request.Form["sifraAdresePosao"];
                string adresaPosaoForma = Request.Form["adresaPosao"];
                string brojAdresePosaoForma = Request.Form["brojAdresePosao"];
                string adresaPosaoGradForma = Request.Form["adresaPosaoGrad"];
                string adresaPosaoOpstinaForma = Request.Form["adresaPosaoOpstina"];
                try
                {
                    //Ukoliko adresa vec postoji vrsi se njen update
                    if (!String.IsNullOrEmpty(sifraAdresePosaoForma) && Convert.ToInt32(sifraAdresePosaoForma) != 0 && ((!String.IsNullOrEmpty(sifraKorisnika) && Convert.ToInt32(sifraKorisnika) != 0) || (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)))
                    {
                        string adresaPosao = null;
                        if (!String.IsNullOrEmpty(adresaPosaoForma))
                        {
                            adresaPosao = adresaPosaoForma;
                        }

                        string brojAdresePosao = null;
                        if (!String.IsNullOrEmpty(brojAdresePosaoForma))
                        {
                            brojAdresePosao = brojAdresePosaoForma;
                        }

                        int? sifraGradaAdresaPosao = null;
                        if (!String.IsNullOrEmpty(adresaPosaoGradForma) && Convert.ToInt32(adresaPosaoGradForma) != 0)
                        {
                            sifraGradaAdresaPosao = Convert.ToInt32(adresaPosaoGradForma);
                        }

                        int? sifraOpstineAdresaPosao = null;
                        if (!String.IsNullOrEmpty(adresaPosaoOpstinaForma) && Convert.ToInt32(adresaPosaoOpstinaForma) != 0)
                        {
                            sifraOpstineAdresaPosao = Convert.ToInt32(adresaPosaoOpstinaForma);
                        }

                        int izvrsenaIzmenaAdrese = AdresaController.IzmenaAdrese(Convert.ToInt32(sifraKorisnika), Convert.ToInt32(sifraAdresePosaoForma), adresaPosao, brojAdresePosao, sifraGradaAdresaPosao, sifraOpstineAdresaPosao);

                        if (izvrsenaIzmenaAdrese == -1)
                        {
                            Session["greska"] = "Nije uspesno izvrsena izmena adrese posla korisnika";
                            return RedirectToAction("Index", "Greska");
                        }

                    }
                    //Ukoliko adresa ne postoji, kreira se nova adresa u bazi
                    else
                    {
                        if (!String.IsNullOrEmpty(adresaPosaoForma) && !String.IsNullOrEmpty(brojAdresePosaoForma) && !String.IsNullOrEmpty(adresaPosaoGradForma) && !String.IsNullOrEmpty(adresaPosaoOpstinaForma))
                        {
                            int izvrsenInsertAdrese = 0;

                            if (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)
                            {
                                izvrsenInsertAdrese = AdresaController.UnosAdresePosao(sifraKorisnikaUBazi, adresaPosaoForma, brojAdresePosaoForma, Convert.ToInt32(adresaPosaoGradForma), Convert.ToInt32(adresaPosaoOpstinaForma));
                            }
                            else
                            {
                                izvrsenInsertAdrese = AdresaController.UnosAdresePosao(Convert.ToInt32(sifraKorisnika), adresaPosaoForma, brojAdresePosaoForma, Convert.ToInt32(adresaPosaoGradForma), Convert.ToInt32(adresaPosaoOpstinaForma));
                            }

                        }
                    }
                }
                catch (Exception)
                {
                    string poruka = "//Preuzimanje podataka sa forme koji su vezani za poslovnu adresu";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");

                }
                //Preuzimanje podataka sa forme vezanih za adresu iz licne karte
                string sifraAdreseLKForma = Request.Form["sifraAdreseLicnaKarta"];
                string adresaLKForma = Request.Form["adresaLicnaKarta"];
                string brojAdreseLKForma = Request.Form["brojAdreseLicnaKarta"];
                string adresaLKGradForma = Request.Form["adresaLicnaKartaGrad"];
                string adresaLKOpstinaForma = Request.Form["adresaLicnaKartaOpstina"];
                try
                {
                    //Ukoliko adresa vec postoji vrsi se njen update u bazi
                    if (!String.IsNullOrEmpty(sifraAdreseLKForma) && Convert.ToInt32(sifraAdreseLKForma) != 0 && ((!String.IsNullOrEmpty(sifraKorisnika) && Convert.ToInt32(sifraKorisnika) != 0) || (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)))
                    {
                        string adresaLK = null;
                        if (!String.IsNullOrEmpty(adresaLKForma))
                        {
                            adresaLK = adresaLKForma;
                        }

                        string brojAdreseLK = null;
                        if (!String.IsNullOrEmpty(brojAdreseLKForma))
                        {
                            brojAdreseLK = brojAdreseLKForma;
                        }

                        int? sifraGradaAdresaLK = null;
                        if (!String.IsNullOrEmpty(adresaLKGradForma) && Convert.ToInt32(adresaLKGradForma) != 0)
                        {
                            sifraGradaAdresaLK = Convert.ToInt32(adresaLKGradForma);
                        }

                        int? sifraOpstineAdresaLK = null;
                        if (!String.IsNullOrEmpty(adresaLKOpstinaForma) && Convert.ToInt32(adresaLKOpstinaForma) != 0)
                        {
                            sifraOpstineAdresaLK = Convert.ToInt32(adresaLKOpstinaForma);
                        }

                        int izvrsenaIzmenaAdrese = AdresaController.IzmenaAdrese(Convert.ToInt32(sifraKorisnika), Convert.ToInt32(sifraAdreseLKForma), adresaLK, brojAdreseLK, sifraGradaAdresaLK, sifraOpstineAdresaLK);

                        if (izvrsenaIzmenaAdrese == -1)
                        {
                            Session["greska"] = "Nije uspesno izvrsena izmena adrese licne karte korisnika";
                            return RedirectToAction("Index", "Greska");
                        }

                    }
                    //Ukoliko adresa ne postoji, kreira se nova u bazi
                    else
                    {
                        if (!String.IsNullOrEmpty(adresaLKForma) && !String.IsNullOrEmpty(brojAdreseLKForma) && !String.IsNullOrEmpty(adresaLKGradForma) && !String.IsNullOrEmpty(adresaLKOpstinaForma))
                        {
                            int izvrsenInsertAdrese = 0;

                            if (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)
                            {
                                izvrsenInsertAdrese = AdresaController.UnosAdreseLicnaKarta(sifraKorisnikaUBazi, adresaLKForma, brojAdreseLKForma, Convert.ToInt32(adresaLKGradForma), Convert.ToInt32(adresaLKOpstinaForma));
                            }
                            else
                            {
                                izvrsenInsertAdrese = AdresaController.UnosAdreseLicnaKarta(Convert.ToInt32(sifraKorisnika), adresaLKForma, brojAdreseLKForma, Convert.ToInt32(adresaLKGradForma), Convert.ToInt32(adresaLKOpstinaForma));
                            }

                        }
                    }
                }
                catch (Exception)
                {
                    string poruka = "//Preuzimanje podataka sa forme vezanih za adresu iz licne karte";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");

                }


                //Preuzimaju se podaci sa forme vezani za privatnu email adresu
                string privatnaEmailAdresaForma = Request.Form["privatnaEmailAdresa"];
                string sifraPrivatnaEmailAdreseForma = Request.Form["sifraPrivatnaEmailAdrese"];
                try
                {
                    //Ukoliko adresa vec postoji, vrsi se njen update u bazi
                    if (!String.IsNullOrEmpty(sifraPrivatnaEmailAdreseForma) && Convert.ToInt32(sifraPrivatnaEmailAdreseForma) != 0)
                    {
                        string privatnaEmailAdresa = null;
                        if (!String.IsNullOrEmpty(privatnaEmailAdresaForma))
                        {
                            privatnaEmailAdresa = privatnaEmailAdresaForma;
                        }

                        int izmenaPrivatneEmail = EmailAdresaController.izmeniEmailAdresu(Convert.ToInt32(sifraPrivatnaEmailAdreseForma), privatnaEmailAdresa);

                        if (izmenaPrivatneEmail == -1)
                        {
                            Session["greska"] = "Nije uspesno izvrsena izmena privatne email adrese";
                            return RedirectToAction("Index", "Greska");
                        }
                    }
                    //Ukoliko adresa ne postoji, kreira se nova u bazi
                    else
                    {
                        if (!String.IsNullOrEmpty(privatnaEmailAdresaForma) && ((!String.IsNullOrEmpty(sifraKorisnika) && Convert.ToInt32(sifraKorisnika) != 0) || (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)))
                        {
                            int izvrsenInsertEmail = 0;

                            if (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)
                            {
                                izvrsenInsertEmail = EmailAdresaController.UnesiPrivatnuEmailAdresu(sifraKorisnikaUBazi, privatnaEmailAdresaForma);
                            }
                            else
                            {
                                izvrsenInsertEmail = EmailAdresaController.UnesiPrivatnuEmailAdresu(Convert.ToInt32(sifraKorisnika), privatnaEmailAdresaForma);
                            }

                            if (izvrsenInsertEmail == -1)
                            {
                                Session["greska"] = "Nije uspesno izvrsen insert privatne email adrese";
                                return RedirectToAction("Index", "Greska");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    string poruka = "//Preuzimaju se podaci sa forme vezani za privatnu email adresu";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");

                }
                //Preuzimanje podataka sa forme vezanih za poslovnu email adresu
                string poslovnaEmailAdresaForma = Request.Form["poslovnaEmailAdresa"];
                string sifraPoslovneEmailAdreseForma = Request.Form["sifraPoslovneEmailAdrese"];
                try
                {
                    //Ukoliko adresa vec postoji, vrsi se update adrese u bazi
                    if (!String.IsNullOrEmpty(sifraPoslovneEmailAdreseForma) && Convert.ToInt32(sifraPoslovneEmailAdreseForma) != 0)
                    {
                        string poslovnaEmailAdresa = null;
                        if (!String.IsNullOrEmpty(poslovnaEmailAdresaForma))
                        {
                            poslovnaEmailAdresa = poslovnaEmailAdresaForma;
                        }

                        int izmenaPoslovneEmail = EmailAdresaController.izmeniEmailAdresu(Convert.ToInt32(sifraPoslovneEmailAdreseForma), poslovnaEmailAdresa);

                        if (izmenaPoslovneEmail == -1)
                        {
                            Session["greska"] = "Nije uspesno izvrsena izmena poslovne email adrese";
                            return RedirectToAction("Index", "Greska");
                        }
                    }
                    //Ukoliko adresa ne postoji, kreira se nova u bazi
                    else
                    {
                        if (!String.IsNullOrEmpty(poslovnaEmailAdresaForma) && ((!String.IsNullOrEmpty(sifraKorisnika) && Convert.ToInt32(sifraKorisnika) != 0) || (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)))
                        {
                            int izvrsenInsertEmail = 0;

                            if (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)
                            {
                                izvrsenInsertEmail = EmailAdresaController.UnesiPoslovnuEmailAdresu(sifraKorisnikaUBazi, poslovnaEmailAdresaForma);
                            }
                            else
                            {
                                izvrsenInsertEmail = EmailAdresaController.UnesiPoslovnuEmailAdresu(Convert.ToInt32(sifraKorisnika), poslovnaEmailAdresaForma);
                            }

                            if (izvrsenInsertEmail == -1)
                            {
                                Session["greska"] = "Nije uspesno izvrsen insert poslovne email adrese";
                                return RedirectToAction("Index", "Greska");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    string poruka = "//Preuzimanje podataka sa forme vezanih za poslovnu email adresu";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");

                }

                //Preuzimaju se podaci sa forme vezani za privatni mobilni telefon
                string privatniLokalMobilniForma = Request.Form["privatniLokalMobilni"];
                string privatniMobilniForma = Request.Form["privatniMobilni"];
                string sifraPrivatnogMobilnogForma = Request.Form["sifraPrivatnogMobilnog"];
                try
                {
                    //Ukoliko mobilni telefon vec postoji, vrsi se njegov update u bazi
                    if (!String.IsNullOrEmpty(sifraPrivatnogMobilnogForma) && Convert.ToInt32(sifraPrivatnogMobilnogForma) != 0)
                    {
                        int? privatniLokalMobilni = null;
                        if (!String.IsNullOrEmpty(privatniLokalMobilniForma))
                        {
                            privatniLokalMobilni = Convert.ToInt32(privatniLokalMobilniForma);
                        }

                        string privatniMobilni = null;
                        if (!String.IsNullOrEmpty(privatniMobilniForma))
                        {
                            privatniMobilni = privatniMobilniForma;
                        }

                        int izmenaPrivatnogMobilnog = MobilniTelefonController.IzmenaMobilnogTelefona(Convert.ToInt32(sifraPrivatnogMobilnogForma), privatniMobilni, privatniLokalMobilni);

                        if (izmenaPrivatnogMobilnog == -1)
                        {
                            Session["greska"] = "Nije uspesno izvrsena izmena privatnog mobilnog telefona";
                            return RedirectToAction("Index", "Greska");
                        }
                    }
                    //Ukoliko mobilni telefon ne postoji, kreira se novi u bazi
                    else
                    {
                        if (!String.IsNullOrEmpty(privatniLokalMobilniForma) && Convert.ToInt32(privatniLokalMobilniForma) != 0 && !String.IsNullOrEmpty(privatniMobilniForma) && Convert.ToInt32(privatniMobilniForma) != 0 && ((!String.IsNullOrEmpty(sifraKorisnika) && Convert.ToInt32(sifraKorisnika) != 0) || (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)))
                        {
                            int unosPrivatnogMobilnog = 0;

                            if (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)
                            {
                                unosPrivatnogMobilnog = MobilniTelefonController.UnosPrivatnogMobilnogTelefona(sifraKorisnikaUBazi, privatniMobilniForma, Convert.ToInt32(privatniLokalMobilniForma));
                            }
                            else
                            {
                                unosPrivatnogMobilnog = MobilniTelefonController.UnosPrivatnogMobilnogTelefona(Convert.ToInt32(sifraKorisnika), privatniMobilniForma, Convert.ToInt32(privatniLokalMobilniForma));
                            }

                            if (unosPrivatnogMobilnog == -1)
                            {
                                Session["greska"] = "Nije uspesno izvrsen unos  privatnog mobilnog telefona";
                                return RedirectToAction("Index", "Greska");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    string poruka = "//Preuzimaju se podaci sa forme vezani za privatni mobilni telefon";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");

                }


                //Preuzimaju se podaci sa forme vezani za sluzbeni mobilni telefon
                string sluzbeniLokalMobilniForma = Request.Form["sluzbeniLokalMobilni"];
                string sluzbeniMobilniForma = Request.Form["sluzbeniMobilni"];
                string sifraSluzbenogMobilnogForma = Request.Form["sifraSluzbenogMobilnog"];
                try
                {

                    //Ukoliko sluzbeni mobilni telefon vec postoji, vrsi se njegov update u bazi
                    if (!String.IsNullOrEmpty(sifraSluzbenogMobilnogForma) && Convert.ToInt32(sifraSluzbenogMobilnogForma) != 0)
                    {
                        int? sluzbeniLokalMobilni = null;
                        if (!String.IsNullOrEmpty(sluzbeniLokalMobilniForma))
                        {
                            sluzbeniLokalMobilni = Convert.ToInt32(sluzbeniLokalMobilniForma);
                        }

                        string sluzbeniMobilni = null;
                        if (!String.IsNullOrEmpty(sluzbeniMobilniForma))
                        {
                            sluzbeniMobilni = sluzbeniMobilniForma;
                        }

                        int izmenaSluzbenogMobilnog = MobilniTelefonController.IzmenaMobilnogTelefona(Convert.ToInt32(sifraSluzbenogMobilnogForma), sluzbeniMobilni, sluzbeniLokalMobilni);

                        if (izmenaSluzbenogMobilnog == -1)
                        {
                            Session["greska"] = "Nije uspesno izvrsena izmena privatnog mobilnog telefona";
                            return RedirectToAction("Index", "Greska");
                        }
                    }
                    //Ukoliko mobilni telefon ne postoji, kreira se novi u bazi
                    else
                    {
                        if (!String.IsNullOrEmpty(sluzbeniLokalMobilniForma) && Convert.ToInt32(sluzbeniLokalMobilniForma) != 0 && !String.IsNullOrEmpty(sluzbeniMobilniForma) && Convert.ToInt32(sluzbeniMobilniForma) != 0 && ((!String.IsNullOrEmpty(sifraKorisnika) && Convert.ToInt32(sifraKorisnika) != 0) || (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)))
                        {
                            int unosSluzbenogMobilnog = 0;

                            if (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)
                            {
                                unosSluzbenogMobilnog = MobilniTelefonController.UnosSluzbenogMobilnogTelefona(sifraKorisnikaUBazi, sluzbeniMobilniForma, Convert.ToInt32(sluzbeniLokalMobilniForma));
                            }
                            else
                            {
                                unosSluzbenogMobilnog = MobilniTelefonController.UnosSluzbenogMobilnogTelefona(Convert.ToInt32(sifraKorisnika), sluzbeniMobilniForma, Convert.ToInt32(sluzbeniLokalMobilniForma));
                            }

                            if (unosSluzbenogMobilnog == -1)
                            {
                                Session["greska"] = "Nije uspesno izvrsen unos  sluzbenog mobilnog telefona";
                                return RedirectToAction("Index", "Greska");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    string poruka = "//Preuzimaju se podaci sa forme vezani za sluzbeni mobilni telefon";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");

                }

                //Preuzimaju se podaci sa forme vezani za poslovni fiksni telefon
                string posaoLokalFiksniForma = Request.Form["posaoLokalFiksni"];
                string posaoFiksniForma = Request.Form["posaoFiksni"];
                string sifraPosaoFiksniForma = Request.Form["sifraPosaoFiksni"];
                try
                {
                    //Ukoliko fiksni telefon vec postoji, vrsi se njegov update u bazi
                    if (!String.IsNullOrEmpty(sifraPosaoFiksniForma) && Convert.ToInt32(sifraPosaoFiksniForma) != 0)
                    {
                        int? posaoLokalFiksni = null;
                        if (!String.IsNullOrEmpty(posaoLokalFiksniForma))
                        {
                            posaoLokalFiksni = Convert.ToInt32(posaoLokalFiksniForma);
                        }

                        string posaoFiksni = null;
                        if (!String.IsNullOrEmpty(posaoFiksniForma))
                        {
                            posaoFiksni = posaoFiksniForma;
                        }

                        int izmenaPoslovnogFiksnog = FiksniTelefonController.IzmenaFiksnogTelefona(Convert.ToInt32(sifraPosaoFiksniForma), posaoFiksni, posaoLokalFiksni);

                        if (izmenaPoslovnogFiksnog == -1)
                        {
                            Session["greska"] = "Nije uspesno izvrsena izmena poslovnog fiksnog telefona";
                            return RedirectToAction("Index", "Greska");
                        }
                    }
                    //Ukoliko fiksni telefon ne postoji, vrsi se njegovo kreiranje u bazi
                    else
                    {
                        if (!String.IsNullOrEmpty(posaoLokalFiksniForma) && Convert.ToInt32(posaoLokalFiksniForma) != 0 && !String.IsNullOrEmpty(posaoFiksniForma) && Convert.ToInt32(posaoFiksniForma) != 0 && ((!String.IsNullOrEmpty(sifraKorisnika) && Convert.ToInt32(sifraKorisnika) != 0) || (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)))
                        {
                            int unosPoslovnogFiksnog = 0;

                            if (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)
                            {
                                unosPoslovnogFiksnog = FiksniTelefonController.UnosPoslovnogFiksnogTelefona(sifraKorisnikaUBazi, posaoFiksniForma, Convert.ToInt32(posaoLokalFiksniForma));
                            }
                            else
                            {
                                unosPoslovnogFiksnog = FiksniTelefonController.UnosPoslovnogFiksnogTelefona(Convert.ToInt32(sifraKorisnika), posaoFiksniForma, Convert.ToInt32(posaoLokalFiksniForma));
                            }

                            if (unosPoslovnogFiksnog == -1)
                            {
                                Session["greska"] = "Nije uspesno izvrsen unos poslovnog fiksnog telefona";
                                return RedirectToAction("Index", "Greska");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    string poruka = "//Preuzimaju se podaci sa forme vezani za poslovni fiksni telefon";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");

                }


                //Preuzimaju se podaci sa forme vezani za kucni fiksni telefon
                string kucaLokalFiksniForma = Request.Form["kucaLokalFiksni"];
                string kucaFiksniForma = Request.Form["kucaFiksni"];
                string sifraKucaFiksniForma = Request.Form["sifraKucaFiksni"];
                try
                {
                    //Ukoliko fiksni telefon vec postoji, vrsi se njegov update u bazi
                    if (!String.IsNullOrEmpty(sifraKucaFiksniForma) && Convert.ToInt32(sifraKucaFiksniForma) != 0)
                    {
                        int? kucaLokalFiksni = null;
                        if (!String.IsNullOrEmpty(kucaLokalFiksniForma))
                        {
                            kucaLokalFiksni = Convert.ToInt32(kucaLokalFiksniForma);
                        }

                        string kucaFiksni = null;
                        if (!String.IsNullOrEmpty(kucaFiksniForma))
                        {
                            kucaFiksni = kucaFiksniForma;
                        }

                        int izmenaKucnogFiksnog = FiksniTelefonController.IzmenaFiksnogTelefona(Convert.ToInt32(sifraKucaFiksniForma), kucaFiksni, kucaLokalFiksni);

                        if (izmenaKucnogFiksnog == -1)
                        {
                            Session["greska"] = "Nije uspesno izvrsena izmena kucnog fiksnog telefona";
                            return RedirectToAction("Index", "Greska");
                        }
                    }
                    //Ukoliko fiksni telefon ne postoji, vrsi se njegovo kreiranje u bazi
                    else
                    {
                        if (!String.IsNullOrEmpty(kucaLokalFiksniForma) && Convert.ToInt32(kucaLokalFiksniForma) != 0 && !String.IsNullOrEmpty(kucaFiksniForma) && Convert.ToInt32(kucaFiksniForma) != 0 && ((!String.IsNullOrEmpty(sifraKorisnika) && Convert.ToInt32(sifraKorisnika) != 0) || (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)))
                        {
                            int unosKucnogFiksnog = 0;

                            if (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)
                            {
                                unosKucnogFiksnog = FiksniTelefonController.UnosKucnogFiksnogTelefona(sifraKorisnikaUBazi, kucaFiksniForma, Convert.ToInt32(kucaLokalFiksniForma));
                            }
                            else
                            {
                                unosKucnogFiksnog = FiksniTelefonController.UnosKucnogFiksnogTelefona(Convert.ToInt32(sifraKorisnika), kucaFiksniForma, Convert.ToInt32(kucaLokalFiksniForma));
                            }

                            if (unosKucnogFiksnog == -1)
                            {
                                Session["greska"] = "Nije uspesno izvrsen unos kucnog fiksnog telefona";
                                return RedirectToAction("Index", "Greska");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    string poruka = "//Preuzimaju se podaci sa forme vezani za kucni fiksni telefon";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");

                }

                //Preuzima se podatak sa forme vezan za sliku
                var fotografija = Request.Files["slika"];
                try
                {
                    //Postavljanje slike korisnika
                    if (fotografija != null && fotografija.ContentLength > 0)
                    {
                        var folder = Server.MapPath("~/image");
                        var ekstenzija = Path.GetExtension(fotografija.FileName);
                        var fotografijaPutanja = Path.ChangeExtension(Guid.NewGuid().ToString(), ekstenzija);
                        var fotografijaPunaPutanja = Path.Combine(folder, fotografijaPutanja);
                        fotografija.SaveAs(fotografijaPunaPutanja);

                        if (Convert.ToInt32(sifraKorisnika) != 0 || (sifraKorisnikaUBazi != 0 && sifraKorisnikaUBazi != -1))
                        {

                            int postavljenaSlika = 0;

                            if (sifraKorisnikaUBazi != -1 && sifraKorisnikaUBazi != 0)
                            {
                                postavljenaSlika = SlikaKorisnikaController.PostavljaneSlikeKorisniku(sifraKorisnikaUBazi, fotografijaPunaPutanja);
                            }
                            else
                            {
                                postavljenaSlika = SlikaKorisnikaController.PostavljaneSlikeKorisniku(Convert.ToInt32(sifraKorisnika), fotografijaPunaPutanja);
                            }


                            if (postavljenaSlika == -1)
                            {
                                Session["greska"] = "Nije uspesno izvrseno postavljanje slike korisnika";
                                return RedirectToAction("Index", "Greska");
                            }
                        }

                    }
                }
                catch (Exception)
                {
                    string poruka = "//Preuzima se podatak sa forme vezan za sliku";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");

                }

                //Na osnovu prava pristupa se vrsi redirekcija na odredjene strane
                Korisnik korisnik = (Korisnik)Session["korisnik"];
                Korisnik korisnikUpdateSesija = Korisnik.VratiKorisnika(korisnik.Id);
                Session["korisnik"] = korisnikUpdateSesija;
             
                PravoPristupa pravoPristupa = PravoPristupa.VratiPravoPristupa(korisnikUpdateSesija.SifraPravaPristupa);
                try
                {
                    
                    int id = Convert.ToInt32(Session["id"]);
                    bool korisnikProfil = Convert.ToBoolean(Session["korisnikProfil"]);
                    if (korisnikProfil && id != 0)
                    {
                       Session["korisnikProfil"] = false;
                       return RedirectToAction("Index", "ProfilKorisnika");

                    }
                    else if(korisnikProfil && sifraKorisnikaUBazi!=0)
                    {
                        Session["korisnikProfil"] = false;
                        return RedirectToAction("Index", "ProfilKorisnika", new { id = sifraKorisnikaUBazi });
                   
                    }
                    else if (pravoPristupa.NazivPristupa == "Pravo administracije")
                    {
                        return RedirectToAction("Index", "AdminProfil");

                    }
                    else if (pravoPristupa.NazivPristupa == "Pravo unosa")
                    {
                        return RedirectToAction("PocetnaKorisnikUnos", "Logovanje");

                    }
                    else if (pravoPristupa.NazivPristupa == "Pravo pregleda")
                    {
                        return RedirectToAction("PocetnaKorisnikPregled", "Logovanje");
                    }
                    else
                    {
                        string poruka = "Korisnik nema pravo pristupa";
                        Session["greska"] = poruka;
                        return RedirectToAction("Index", "Greska");
                    }
                }
                catch (Exception)
                {
                    string poruka = "//Na osnovu prava pristupa se vrsi redirekcija na odredjene strane";
                    Session["greska"] = poruka;
                    return RedirectToAction("Index", "Greska");
                }
        }
    }
}

