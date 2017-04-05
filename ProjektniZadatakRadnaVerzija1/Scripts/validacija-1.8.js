
{// Promenljive 
    var korisnickoime = document.getElementById("korisnickoime");
    var sifra = document.getElementById("sifra");
    var ime = document.getElementById("imeID");
    var prezime= document.getElementById("prezime");
    var jmbg = document.getElementById("jmbg");
    var brojlicnekarte = document.getElementById("brojlicnekarte");
    var imeroditelja = document.getElementById("imeroditelja");
    var datumrodjenja = document.getElementById("datumrodjenja");
    var mestorodjenja = document.getElementById("mestorodjenja");
    var opstinarodjenja = document.getElementById("opstinarodjenja");
    var pravapristupa = document.getElementById("pravapristupa");
    var beleska = document.getElementById("beleska");
    var brojacbeleska = document.getElementById("brojacBeleska");
    var mail1 = document.getElementById("mail1");
    var mail2 = document.getElementById("mail2");
    var pol = document.getElementById("pol");
    var pol1 = document.getElementById("pol1");
    var pol2 = document.getElementById("pol2");

    var brisanje = document.getElementById("brisanje");
	
    var potvrda = document.getElementById("potvrda");

    var izborslike = document.getElementById("izborslike");
	
    var adresa1naziv = document.getElementById("adresa1naziv");
    var adresa1broj = document.getElementById("adresa1broj");
    var adresa1grad = document.getElementById("adresa1grad");
    var adresa1opstina = document.getElementById("adresa1opstina");
	
    var adresa2naziv = document.getElementById("adresa2naziv");
    var adresa2broj = document.getElementById("adresa2broj");
    var adresa2grad = document.getElementById("adresa2grad");
    var adresa2opstina = document.getElementById("adresa2opstina");
	
    var adresa3naziv = document.getElementById("adresa3naziv");
    var adresa3broj = document.getElementById("adresa3broj");
    var adresa3grad = document.getElementById("adresa3grad");
    var adresa3opstina = document.getElementById("adresa3opstina");
	
    var mobilni1pozivni = document.getElementById("mobilni1pozivni");
    var mobilni1broj = document.getElementById("mobilni1broj");
	
    var mobilni2pozivni = document.getElementById("mobilni2pozivni");
    var mobilni2broj = document.getElementById("mobilni2broj");
	
    var fiksni1pozivni = document.getElementById("fiksni1pozivni");
    var fiksni1broj = document.getElementById("fiksni1broj");
	
    var fiksni2pozivni = document.getElementById("fiksni2pozivni");
    var fiksni2broj = document.getElementById("fiksni2broj");
	
    var zelenaPozadina = '#93f484';
    var crvenaPozadina = '#f74242';
    // Zelena boja - #93f484
    // Crvena boja - #f74242
	
    var vtekst = /^[a-zA-Z]+$/; // a-z A-Z
    var vbroj = /^[0-9]+$/; // 0-9
    var vtekstbroj = /^[0-9a-zA-Z]+$/; // a-z A-Z 0-9
    var vtekstadresa = /^[a-zA-Z\s]*$/; // a-z A-Z space
    var vtekstbrojadresa = /^[0-9a-zA-Z]+$/; // a-z A-Z 0-9

}

{// JMBG Validacija 

    var dataValidator = (function proveraJMBG() {
        "use strict";

        function dataValidator() { }

        dataValidator.prototype.validanBroj = function (vrednost) {
            if (typeof vrednost !== "undefined" && vrednost !== null) {
                vrednost = vrednost.replace(',', '.');
                return !isNaN(parseFloat(vrednost)) && isFinite(vrednost);
            }
            return false;
        };

        dataValidator.prototype.validanDatum = function (vrednost) {
            if (Object.prototype.toString.call(vrednost) === "[object Date]")
                return !isNaN(vrednost.getTime());
             return false;
        };

        dataValidator.prototype.validanJMBG = function (jmbg) {
            if (typeof jmbg !== "undefined" && jmbg !== null && jmbg.length === 13 && dataValidator.prototype.validanBroj(jmbg)) {
                var dan = parseInt(jmbg.substring(0, 2), 10);
                var mesec = parseInt(jmbg.substring(2, 4), 10) - 1;
                var godina = parseInt("2" + jmbg.substring(4, 7), 10);
                if (dataValidator.prototype.validanDatum(new Date(godina, mesec, dan))) {
                    return /^60|66$/.test(jmbg.substring(7, 9)) ||
                    parseInt(jmbg.charAt(12), 10) === mod11(jmbg.substring(0, 12), function (kb) { return kb === 11 ? 0 : ((kb === 10) ? "X" : kb); });
                }
            }
             return false;
        };

        dataValidator.prototype.validanMod97 = function (broj, validation_error_callback) {
            if (typeof validation_error_callback !== "undefined") {
                var validation_errors = [];
                if (broj.length <= 2)
                    validation_errors.push("Nevalidna dužina broja");
                for (var i = 0; i < broj.length; i++) {
                    var validno = false;
                    var slovo = broj.charAt(i);
                    if (slovoUBroj(slovo) !== null) validno = true;
                    else validation_errors.push("Nevalidan znak: (\'" + slovo + "\') na poziciji " + (i + 1).toString());
                }
                if (validation_errors.length !== 0)
                    validation_error_callback(validation_errors);
            }
            return dataValidator.prototype.kontrolniBrojMod97(broj.substring(2)) === broj.substring(0, 2);
        };

        dataValidator.prototype.kontrolniBrojMod97 = function (broj) {
            if (typeof broj === "undefined" || broj === null || broj === "") return null;
            var zakontrolu = "";
            for (var i = 0; i < broj.length; i++) {
                var vrednost = slovoUBroj(broj.charAt(i));
                if (vrednost === null) return null;
                else zakontrolu += vrednost.toString();
            }
            if (dataValidator.prototype.validanBroj(zakontrolu)) {
                var rez = mod97(zakontrolu).toString();
                return rez.length === 1 ? rez = "0" + rez : rez;
            }
            else return null;
        };

        dataValidator.prototype.kontrolniBrojMod22 = function (broj) {
            return (dataValidator.prototype.validanBroj(broj)) ? mod22(broj).toString() : null;
        };

        dataValidator.prototype.kontrolniBrojMod11 = function (broj, dodatni_uslov) {
            return (dataValidator.prototype.validanBroj(broj)) ? mod11(broj, dodatni_uslov).toString() : null;
        };

        dataValidator.prototype.kontrolniBrojMod11Sub = function (broj, dodatni_uslov) {
            return (dataValidator.prototype.validanBroj(broj)) ? mod11sub(broj, dodatni_uslov).toString() : null;
        };

        function slovoUBroj(slovo) {
            return slovo === "-" ? "" :
				((dataValidator.prototype.validanBroj(slovo)) ? slovo : (_slova_za_kontrolni_broj[slovo] || null));
        }

        function mod97(br) {
            var kb = 0, os = 100;
            for (var x = br.length - 1; x >= 0; x--) {
                kb = (kb + (os * parseInt(br.charAt(x), 10))) % 97;
                os = (os * 10) % 97;
            }
            kb = 98 - kb;
            return kb;
        }

        function mod22(br) {
            var kb = mod11sub(br);
            return kb > 9 ? kb -= 10 : kb;
        }

        function mod11(br, dodatni_uslov) {
            var kb = 0;
            for (var i = br.length - 1, mnozilac = 2; i >= 0; i--) {
                kb += parseInt(br.charAt(i), 10) * mnozilac;
                mnozilac = mnozilac === 7 ? 2 : mnozilac + 1;
            }
            kb = 11 - (kb % 11);
            return (typeof dodatni_uslov === "undefined") ? kb : dodatni_uslov(kb);
        }

        function mod11sub(br, dodatni_uslov) {
            var kb = 0;
            for (var i = 0, mnozilac = 7; i < br.length; i++) {
                kb += parseInt(br.charAt(i), 10) * mnozilac;
                mnozilac = mnozilac === 2 ? 7 : mnozilac - 1;
            }
            kb = 11 - (kb % 11);
            return (typeof dodatni_uslov === "undefined") ? kb : dodatni_uslov(kb);
        }

        var _slova_za_kontrolni_broj =
        {
            "A": 10, "B": 11, "C": 12, "D": 13, "E": 14, "F": 15, "G": 16, "H": 17, "I": 18, "J": 19,
            "K": 20, "L": 21, "M": 22, "N": 23, "O": 24, "P": 25, "Q": 26, "R": 27, "S": 28, "T": 29,
            "U": 30, "V": 31, "W": 32, "X": 33, "Y": 34, "Z": 35
        };
        return dataValidator;

    })();

    var JMBG = function (jmbg) {
        "use strict";
        var _jmbg, _region, _dan, _mesec, _godina, _rbr, _kontrolni;
        var _validan = dataValidator.prototype.validanJMBG(jmbg);
        if (_validan) {
            _jmbg = jmbg;
            Parse();
        }

        this.pol = function () {
            if (_validan) return _rbr > 500 ? "Z" : "M";
            return null;
        };

        this.region = function () {
            return regioni[_region] || null;
        };

        this.redniBrojRodjenja = function () {
            if (_validan) return _rbr > 499 ? _rbr - 499 : _rbr + 1;
            else return null;
        };

        this.validan = function () {
            return _validan;
        };

        this.datumRodjenja = function () {
            return _validan ? new Date(_godina, _mesec, _dan) : null;
        };

        this.toString = function () {
            return _validan ? _jmbg : null;
        };

        function Parse() {
            _dan = parseInt(_jmbg.substring(0, 2), 10);
            _mesec = parseInt(_jmbg.substring(2, 4), 10) - 1;
            _godina = parseInt(_jmbg.substring(4, 7), 10);
            _region = _jmbg.substring(7, 9);
            _rbr = parseInt(_jmbg.substring(9, 12), 10);
            _kontrolni = parseInt(_jmbg.charAt(12), 10);

            var tekuca_god = new Date().getFullYear() % 1000;
            var tekuci_mil = new Date().getFullYear() - tekuca_god;

            if (_godina > tekuca_god)
                _godina += tekuci_mil - 1000;
            else _godina += tekuci_mil;
        }
    };
}


function slova(ulaz) { // samo slova

    var temp = /^[a-zA-Z]+$/;
    if (ulaz.value !== "") {
        if (ulaz.value.match(temp)) {
            ulaz.style.background = zelenaPozadina;
            return true;
        }
        else {
            ulaz.style.background = crvenaPozadina;
            return false;

        }
    }
    else
    {
        ulaz.style.background = "";
        return true;
    }
}

function slovarazmak(ulaz) { // samo slova

    var temp = /^[a-zA-Z\s]*$/;

    if (ulaz.value !== "") {
        if (ulaz.value.match(temp)) {
            ulaz.style.background = zelenaPozadina;
            return true;
        }
        else {
            ulaz.style.background = crvenaPozadina;
            return false;

        }
    }
    else {
        ulaz.style.background = "";
        return true;
    }
}

function brojevi(ulaz) { // samo brojevi

    var temp = /^[0-9]+$/;
		
    if (ulaz.value !== "") {
        if (ulaz.value.match(temp)) {
            ulaz.style.background = zelenaPozadina;
            return true;
        }
        else {
            ulaz.style.background = crvenaPozadina;
            return false;

        }
    }
    else {
        ulaz.style.background = "";
        return true;
    }
}

function slovabrojevi(ulaz) { // tekst ili brojevi

    var temp = /^[0-9a-zA-Z]+$/;
		
    if (ulaz.value !== "") {
        if (ulaz.value.match(temp)) {
            ulaz.style.background = zelenaPozadina;
            return true;
        }
        else {
            ulaz.style.background = crvenaPozadina;
            return false;

        }
    }
    else {
        ulaz.style.background = "";
        return true;
    }
}
// Podaci koji su obavezni
function validacijaKorisnickogImena() { // samo slova - minimum 5 karaktera, maximum 20

    var ulaz = /^(?=.*[a-zA-Z]+.*)[a-zA-Z]{5,20}$/;


    if (korisnickoime.value.match(ulaz)) {
        korisnickoime.style.background = zelenaPozadina;
        return true;
    }
    else {
        korisnickoime.style.background = crvenaPozadina;
        return false;
    }
}

function validacijaSifre() { // minimumu 1 slovo ili karakter - minimum 8 karaktera, maximum 20

    var ulaz = /^(?=.*[0-9]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z]{8,20}$/;


    if (sifra.value.match(ulaz)) {
        sifra.style.background = zelenaPozadina;
        return true;
    }
    else {
        sifra.style.background = crvenaPozadina;
        return false;
    }
}

function validacijaPravaPristupa() { // izabrana opcija ili ne 

    if (pravapristupa.options[pravapristupa.selectedIndex].value != "0") {
        // Ukoliko je ispunjen uslov
        pravapristupa.style.background = zelenaPozadina;
        return true;
    }
    else {
        // Ukoliko nije ispunjen uslov

        pravapristupa.style.background = crvenaPozadina;
        return false;
    }
}

function validacijaPola() { // provera da li je pol izabran

    if (pol.value != 0) {
        polovipozadina.style.background = zelenaPozadina;
        return true;

    }
    else {
        polovipozadina.style.background = crvenaPozadina;
        return false;
    }

}
  
function validacijaIme(){ // samo slova - minimum 2 karaktera zbog Chung Li-ja, maximum 15 )
      
    var ulaz = /^(?=.*[a-zA-Z]+.*)[a-zA-Z]{2,15}$/;
		
    if(ime.value.match(ulaz))
    {
        ime.style.background = zelenaPozadina;
        return true;
    }
    else
    {
        ime.style.background = crvenaPozadina;
        return false;
    }
}
	  
function validacijaPrezime(){ // samo slova - minimum 3 karaktera, maximum 20
	
    var ulaz = /^(?=.*[a-zA-Z]+.*)[a-zA-Z]{3,20}$/;
		
    if(prezime.value.match(ulaz))
    {
        prezime.style.background = zelenaPozadina;
        return true;
    }
    else
    {
        prezime.style.background = crvenaPozadina;
        return false;
    }
}

function validacijaBrojLicneKarte() { // samo brojevi - maximum 9

    var ulaz = /^[0-9]{9}$/;
    if (brojlicnekarte.value.match(ulaz)) {
        brojlicnekarte.style.background = zelenaPozadina;
        return true;
    }
    else {
        brojlicnekarte.style.background = crvenaPozadina;
        return false;
    }
}
// Podaci koji nisu obavezni
function brojacBeleska() { // max 500 karaktera

    var el_t = document.getElementById('beleska');
    var length = el_t.getAttribute("maxlength");
    var el_c = document.getElementById('brojac');
    el_c.innerHTML = length;
    el_t.onkeyup = function () {
        document.getElementById('brojac').innerHTML = (length - this.value.length) + "/500";
    };
}

function validacijaPraznaPolja(ulaz){ // provera da li je prazno polje
	
    var praznoK = ulaz.value;
	
    if (praznoK == "" || praznoP == "")
    {
        alert("Greska");
        return false;
    }
    else
    {
        return true;
    }
}

function validacijaImeRoditelja(){ // samo slova - minimum 2 karaktera, maximum 15
		
    var ulaz = /^(?=.*[a-zA-Z]+.*)[a-zA-Z]{2,15}$/;
    if (imeroditelja.value !== "")
    {
        if(imeroditelja.value.match(ulaz))
        {
            imeroditelja.style.background = zelenaPozadina;
            return true;
        }
        else
        {
            imeroditelja.style.background = crvenaPozadina;
            return false;
        }
    }
    else
    {
        imeroditelja.style.background = "";
        return true;
    }

}	  	
		
function validacijaMestoOpstinaRodjenja() { // provera da li su i mesto rodjenja i opstina izabrani ili ne 

    var gradValue = mestorodjenja.options[mestorodjenja.selectedIndex].value;
    var opstinaValue = opstinarodjenja.options[opstinarodjenja.selectedIndex].value;

    if (gradValue !== 0 && opstinaValue !== 0)
    {
            if (gradValue == 1 && (opstinaValue < 17 && opstinaValue > 0))
            {	
                mestorodjenja.style.background = zelenaPozadina;
                opstinarodjenja.style.background = zelenaPozadina;
                return true;
            }
            if(gradValue==2 && (((opstinaValue>17 && opstinaValue<20)) ||  opstinaValue==30))
            {	
                mestorodjenja.style.background = zelenaPozadina;
                opstinarodjenja.style.background = zelenaPozadina;
                return true;
            }
            if(gradValue==3 && (opstinaValue<25 && opstinaValue>19))
            {	
                mestorodjenja.style.background = zelenaPozadina;
                opstinarodjenja.style.background = zelenaPozadina;
                return true;
            }
            if(gradValue==4 && (opstinaValue<30 && opstinaValue>24))
            {	
                mestorodjenja.style.background = zelenaPozadina;
                opstinarodjenja.style.background = zelenaPozadina;
                return true;
            }
            else
            {	
                mestorodjenja.style.background = crvenaPozadina;
                opstinarodjenja.style.background = crvenaPozadina;
                return false;
            }
    }
    else
    {
        mestorodjenja.style.background = "";
        opstinarodjenja.style.background = "";
        return true;
    }


    
}
  
function validacijaAdresa1(){ // provera da li su izabrani grad i opstina ili ne

    if((adresa1grad.options[adresa1grad.selectedIndex ].value=="0" && adresa1opstina.options[adresa1opstina.selectedIndex ].value=="0" && 
        adresa1naziv.value=="" && adresa1broj.value=="") || 
        (adresa1grad.options[adresa1grad.selectedIndex ].value!="0" && adresa1opstina.options[adresa1opstina.selectedIndex ].value!="0" &&
        adresa1naziv.value.match(vtekstadresa) && adresa1broj.value.match(vtekstbrojadresa)))
    {
        // Ukoliko je ispunjen uslov
        adresa1naziv.style.background = zelenaPozadina;
        adresa1broj.style.background = zelenaPozadina;
        adresa1grad.style.background = zelenaPozadina;
        adresa1opstina.style.background = zelenaPozadina;
        return true;
    }
    else
    {
        // ukoliko nije ispunjen uslov
        adresa1naziv.style.background = crvenaPozadina;
        adresa1broj.style.background = crvenaPozadina;
        adresa1grad.style.background = crvenaPozadina;
        adresa1opstina.style.background = crvenaPozadina;
        return false;
    }
}

function validacijaAdresa2(){ // provera da li su izabrani grad i opstina ili ne

    if((adresa2grad.options[adresa2grad.selectedIndex ].value=="0" && adresa2opstina.options[adresa2opstina.selectedIndex ].value=="0" && 
          adresa2naziv.value=="" && adresa2broj.value=="") || 
          (adresa2grad.options[adresa2grad.selectedIndex ].value!="0" && adresa2opstina.options[adresa2opstina.selectedIndex ].value!="0" &&
          adresa2naziv.value.match(vtekstadresa) && adresa2broj.value.match(vtekstbrojadresa)))
    {
        // Ukoliko je ispunjen uslov
        adresa2naziv.style.background = zelenaPozadina;
        adresa2broj.style.background = zelenaPozadina;
        adresa2grad.style.background = zelenaPozadina;
        adresa2opstina.style.background = zelenaPozadina;
        return true;
    }
    else
    {
        // ukoliko nije ispunjen uslov
        adresa2naziv.style.background = crvenaPozadina;
        adresa2broj.style.background = crvenaPozadina;
        adresa2grad.style.background = crvenaPozadina;
        adresa2opstina.style.background = crvenaPozadina;
        return false;
    }
}	  

function validacijaAdresa3(){ // provera da li su izabrani grad i opstina ili ne

    if((adresa3grad.options[adresa3grad.selectedIndex ].value=="0" && adresa3opstina.options[adresa3opstina.selectedIndex ].value=="0" && 
        adresa3naziv.value=="" && adresa3broj.value=="") || 
        (adresa3grad.options[adresa3grad.selectedIndex ].value!="0" && adresa3opstina.options[adresa3opstina.selectedIndex ].value!="0" &&
        adresa3naziv.value.match(vtekstadresa) && adresa3broj.value.match(vtekstbrojadresa)))
    {
        // Ukoliko je ispunjen uslov
        adresa3naziv.style.background = zelenaPozadina;
        adresa3broj.style.background = zelenaPozadina;
        adresa3grad.style.background = zelenaPozadina;
        adresa3opstina.style.background = zelenaPozadina;
        return true;
    }
    else
    {
        // ukoliko nije ispunjen uslov
        adresa3naziv.style.background = crvenaPozadina;
        adresa3broj.style.background = crvenaPozadina;
        adresa3grad.style.background = crvenaPozadina;
        adresa3opstina.style.background = crvenaPozadina;
        return false;
    }
}	  
	    
function validacijaEmail1() { // maximum 30 karaktera po formatu **@*.** - * predstavlja karakter

    var x = mail1.value;
    var atpos = x.indexOf("@");
    var dotpos = x.lastIndexOf(".");

    if (x !== "")
    {
        if ((atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) && x.length < 31) {
            mail1.style.background = crvenaPozadina;
            return false;
        }
        else {
            mail1.style.background = zelenaPozadina;
            return true;
        }
    }
    else
    {
        mail1.style.background = "";
        return true;
    }

   
}

function validacijaEmail2() { // maximum 30 karaktera po formatu **@*.** - * predstavlja karakter

    var x = mail2.value;
    var atpos = x.indexOf("@");
    var dotpos = x.lastIndexOf(".");

    if (x !== "")
    {
        if ((atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) && x.length < 31) {
            mail2.style.background = crvenaPozadina;
            return false;
        }
        else {
            mail2.style.background = zelenaPozadina;
            return true;
        }
    }
    else
    {
        mail2.style.background = "";
        return true;
    }
    
}

function validacijaMobilni1(){ // samo brojevi - minimum 6 karaktera - maximum 7
    var ulaz = /^[0-9]{6,7}$/;

    if (mobilni1pozivni.options[mobilni1pozivni.selectedIndex].value !== "0" || mobilni1broj.value !== "")
    {
        if (mobilni1pozivni.options[mobilni1pozivni.selectedIndex].value != "0" && mobilni1broj.value != "" && mobilni1broj.value.match(ulaz)) {
            mobilni1broj.style.background = zelenaPozadina;
            mobilni1pozivni.style.background = zelenaPozadina;
            return true;
        }
        else {
            mobilni1broj.style.background = crvenaPozadina;
            mobilni1pozivni.style.background = crvenaPozadina;
            return false;
        }
    }
    else
    {
        mobilni1broj.style.background = "";
        mobilni1pozivni.style.background = "";
    }
    
}

function validacijaMobilni2(){ // samo brojevi - minimum 6 karaktera - maximum 7
    var ulaz = /^[0-9]{6,7}$/;
    
    if (mobilni2pozivni.options[mobilni2pozivni.selectedIndex].value !== "0" || mobilni2broj.value !== "") {
        if (mobilni2pozivni.options[mobilni2pozivni.selectedIndex].value != "0" && mobilni2broj.value != "" && mobilni2broj.value.match(ulaz)) {
            mobilni2broj.style.background = zelenaPozadina;
            mobilni2pozivni.style.background = zelenaPozadina;
            return true;
        }
        else {
            mobilni2broj.style.background = crvenaPozadina;
            mobilni2pozivni.style.background = crvenaPozadina;
            return false;
        }
    }
    else {
        mobilni2broj.style.background = "";
        mobilni2pozivni.style.background = "";
    }
}

function validacijaFiksni1(){ // samo brojevi - minimum 6 karaktera - maximum 7
		
    var ulaz = /^[0-9]{6,7}$/;
    if (fiksni1pozivni.options[fiksni1pozivni.selectedIndex].value !== "0" || fiksni1broj.value !== "") {
        if (fiksni1pozivni.options[fiksni1pozivni.selectedIndex].value != "0" && fiksni1broj.value != "" && fiksni1broj.value.match(ulaz)) {
            fiksni1broj.style.background = zelenaPozadina;
            fiksni1pozivni.style.background = zelenaPozadina;
            return true;
        }
        else {
            fiksni1broj.style.background = crvenaPozadina;
            fiksni1pozivni.style.background = crvenaPozadina;
            return false;
        }
    }
    else {
        fiksni1broj.style.background = "";
        fiksni1pozivni.style.background = "";
    }
}

function validacijaFiksni2(){ // samo brojevi - minimum 6 karaktera - maximum 7
		
    var ulaz = /^[0-9]{6,7}$/;
    if (fiksni2pozivni.options[fiksni2pozivni.selectedIndex].value !== "0" || fiksni2broj.value !== "") {
        if (fiksni2pozivni.options[fiksni2pozivni.selectedIndex].value != "0" && fiksni2broj.value != "" && fiksni2broj.value.match(ulaz)) {
            fiksni2broj.style.background = zelenaPozadina;
            fiksni2pozivni.style.background = zelenaPozadina;
            return true;
        }
        else {
            fiksni2broj.style.background = crvenaPozadina;
            fiksni2pozivni.style.background = crvenaPozadina;
            return false;
        }
    }
    else {
        fiksni2broj.style.background = "";
        fiksni2pozivni.style.background = "";
    }
}

function validacijaSlike() { // provera da li su formati odgovarajuci jpg, jpeg, gif, png, bmp

    var ekstenzije = new Array("jpg", "jpeg", "gif", "png", "bmp");

    var fajl = izborslike.value;
    var image_length = izborslike.value.length;
    var pom = fajl.lastIndexOf('.') + 1;
    var ostatak = fajl.substring(pom, image_length);
    var ekstenzija = ostatak.toLowerCase();
    for (i = 0; i < ekstenzije.length; i++) {
        if (ekstenzije[i] == ekstenzija) {
            izborslike.style.background = zelenaPozadina;
            document.getElementById("potvrda").disabled = false;
            return true;
        }
    }
    
    izborslike.style.background = crvenaPozadina;
    return false;
}
		
function validacijaAdresaRange1(){ // ispravnost izabrane opstine na osnovu izabranog grada grada 
    var gradValue = adresa1grad.options[adresa1grad.selectedIndex].value;
    var opstinaValue = adresa1opstina.options[adresa1opstina.selectedIndex].value;
    if(gradValue==1 && (opstinaValue<17  && opstinaValue>0))
    {	
        adresa1grad.style.background = zelenaPozadina;
        adresa1opstina.style.background = zelenaPozadina;
        return true;
    }
    if(gradValue==2 && (((opstinaValue>17 && opstinaValue<20)) ||  opstinaValue==30))
    {	
        adresa1grad.style.background = zelenaPozadina;
        adresa1opstina.style.background = zelenaPozadina;
        return true;
    }
    if(gradValue==3 && (opstinaValue<25 && opstinaValue>19))
    {	
        adresa1grad.style.background = zelenaPozadina;
        adresa1opstina.style.background = zelenaPozadina;
        return true;
    }
    if(gradValue==4 && (opstinaValue<30 && opstinaValue>24))
    {	
        adresa1grad.style.background = zelenaPozadina;
        adresa1opstina.style.background = zelenaPozadina;
        return true;
    }
    else
    {	
        adresa1grad.style.background = crvenaPozadina;
        adresa1opstina.style.background = crvenaPozadina;
        return false;
    }
}

function validacijaAdresaRange2(){ // ispravnost izabrane opstine na osnovu izabranog grada grada 
    var gradValue = adresa2grad.options[adresa2grad.selectedIndex].value;
    var opstinaValue = adresa2opstina.options[adresa2opstina.selectedIndex].value;
    if(gradValue==1 && (opstinaValue<17  && opstinaValue>0))
    {	
        adresa2grad.style.background = zelenaPozadina;
        adresa2opstina.style.background = zelenaPozadina;
        return true;
    }
    if(gradValue==2 && (((opstinaValue>17 && opstinaValue<20)) ||  opstinaValue==30))
    {	
        adresa2grad.style.background = zelenaPozadina;
        adresa2opstina.style.background = zelenaPozadina;
        return true;
    }
    if(gradValue==3 && (opstinaValue<25 && opstinaValue>19))
    {	
        adresa2grad.style.background = zelenaPozadina;
        adresa2opstina.style.background = zelenaPozadina;
        return true;
    }
    if(gradValue==4 && (opstinaValue<30 && opstinaValue>24))
    {	
        adresa2grad.style.background = zelenaPozadina;
        adresa2opstina.style.background = zelenaPozadina;
        return true;
    }
    else
    {	
        adresa2grad.style.background = crvenaPozadina;
        adresa2opstina.style.background = crvenaPozadina;
        return false;
    }
}

function validacijaAdresaRange3(){ // ispravnost izabrane opstine na osnovu izabranog grada grada 
    var gradValue = adresa3grad.options[adresa3grad.selectedIndex].value;
    var opstinaValue = adresa3opstina.options[adresa3opstina.selectedIndex].value;
    if(gradValue==1 && (opstinaValue<17  && opstinaValue>0))
    {	
        adresa3grad.style.background = zelenaPozadina;
        adresa3opstina.style.background = zelenaPozadina;
        return true;
    }
    if(gradValue==2 && (((opstinaValue>17 && opstinaValue<20)) ||  opstinaValue==30))
    {	
        adresa3grad.style.background = zelenaPozadina;
        adresa3opstina.style.background = zelenaPozadina;
        return true;
    }
    if(gradValue==3 && (opstinaValue<25 && opstinaValue>19))
    {	
        adresa3grad.style.background = zelenaPozadina;
        adresa3opstina.style.background = zelenaPozadina;
        return true;
    }
    if(gradValue==4 && (opstinaValue<30 && opstinaValue>24))
    {	
        adresa3grad.style.background = zelenaPozadina;
        adresa3opstina.style.background = zelenaPozadina;
        return true;
    }
    else
    {	
        adresa3grad.style.background = crvenaPozadina;
        adresa3opstina.style.background = crvenaPozadina;
        return false;
    }
}
			
function validacijaDatum(){ // proverava da li je datum ispunjen
    if(datumrodjenja!="" || datumrodjenja!=null )
    {	
        datumrodjenja.style.background = zelenaPozadina;
        return true;
    }
    else
    {
        datumrodjenja.style.background = crvenaPozadina;
        return false;
    }
	
	
}

function selekcijaPola(){
		
        pol.checked = true;
}

function validacijaSubmit(){ // provera korisnickoime>lozinka>pravopristupa>pol>ime>prezime>jmbg>brojlicnekarte>datumrodjenja
	
    if(validacijaKorisnickogImena(korisnickoime)!== true)
    {	
        alert("Korisničko nije ime ispravno ili nije popunjeno.");
        return false;	
    }
		
    if(validacijaSifre(sifra)!== true)
    {
        alert("Šifra nije ispravna ili nije popunjena.");
        return false;
    }
		
    if(validacijaPravaPristupa(pravapristupa)!== true)
    {
        alert("Pravo pristupa nije izabrano.");
        return false;
    }

    if (validacijaPola() !== true) {
        alert("Pol nije izabran.");
        return false;
    }
		
    if(validacijaIme(ime)!== true)
    {
        alert("Ime nije ispravno ili nije popunjeno.");
        return false;
    }

    if(validacijaPrezime(prezime)!== true)
    {
        alert("Prezime nije ispravno ili nije popunjeno.");
        return false;
    }
		
    if(jmbg.value == "" || jmbg.value == null)
    {
        alert("JMBG nije ispravan ili nije popunjen.");
        return false;
    }
		
    if(validacijaBrojLicneKarte(brojlicnekarte)!== true)
    {
        alert("Broj lične karte nije ispravan ili nije popunjen.");
        return false;
    }

    if (validacijaAdresa1() !== true) {
        alert("Adresa Kuca nije ispravna.");
        return false;
    }
    if (validacijaAdresa2() !== true) {
        alert("Adresa Posao nije ispravna.");
        return false;
    }
    if (validacijaAdresa3() !== true) {
        alert("Adresa Licna Karta nije ispravna.");
        return false;
    }

    alert("Uneti podaci su prihvaćeni.");
    return true;	
}

function validacijaObaveznihPodataka() {

    if(korisnickoime.style.background==zelenaPozadina && sifra.style.background==zelenaPozadina && pravapristupa.style.background==zelenaPozadina &&
        pol.style.background==zelenaPozadina && ime.style.background==zelenaPozadina && prezime.style.background==zelenaPozadina && 
         brojlicnekarte.style.background==zelenaPozadina)
    {
        return true;
    }
    else
    {
        return false;
    }
}

function ugasiSve() {
    korisnickoime.disabled = "disabled";
    korisnickoime.value = "KorisnickoIme";
    sifra.disabled = "disabled";
    sifra.value = "123456789a";
    ime.disabled = "disabled";
    prezime.disabled = "disabled";
    jmbg.disabled = "disabled";
    brojlicnekarte.disabled = "disabled";
    imeroditelja.disabled = "disabled";
    datumrodjenja.disabled = "disabled";
    mestorodjenja.disabled = "disabled";
    opstinarodjenja.disabled = "disabled";
    pravapristupa.disabled = "disabled";
    beleska.disabled = "disabled";
    mail1.disabled = "disabled";
    mail2.disabled = "disabled";
    pol.disabled = "disabled";

    izborslike.disabled = "disabled";

    adresa1naziv.disabled = "disabled";
    adresa1broj.disabled = "disabled";
    adresa1grad.disabled = "disabled";
    adresa1opstina.disabled = "disabled";

    adresa2naziv.disabled = "disabled";
    adresa2broj.disabled = "disabled";
    adresa2grad.disabled = "disabled";
    adresa2opstina.disabled = "disabled";

    adresa3naziv.disabled = "disabled";
    adresa3broj.disabled = "disabled";
    adresa3grad.disabled = "disabled";
    adresa3opstina.disabled = "disabled";

    mobilni1pozivni.disabled = "disabled";
    mobilni1broj.disabled = "disabled";

    mobilni2pozivni.disabled = "disabled";
    mobilni2broj.disabled = "disabled";

    fiksni1pozivni.disabled = "disabled";
    fiksni1broj.disabled = "disabled";

    fiksni2pozivni.disabled = "disabled";
    fiksni2broj.disabled = "disabled";

}

function ugasiKorisnickoIme() {
    korisnickoime.disabled = "disabled";
}

function myFunction() {
    // Declare variables
    var input, filter, ul, li, a, i;
    input = document.getElementById('myInput');
    filter = input.value.toUpperCase();
    ul = document.getElementById("myUL");
    li = ul.getElementsByTagName('li');

    // Loop through all list items, and hide those who don't match the search query
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("a")[0];
        if (a.innerHTML.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}

function potvrdaBrisanja() {
    
    var txt;
    var r = confirm("Da li ste sigurni da zelite da obrisete korisnika?");
    if (r == true) {
        return true;
    } else {
        return false;
    }
}


