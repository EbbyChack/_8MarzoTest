using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8MarzoTest.Models
{
    public class Prenotazione
    {
        [HiddenInput(DisplayValue = false)]
        public int IdPrenotazione { get; set; }
        public int IdCliente { get; set; }
        public int IdCamera { get; set; }
        public DateTime DataPrenotazione { get; set; }
        public int Anno { get; set; }
        public DateTime Dal { get; set; }
        public DateTime Al { get; set; }
        public double Caparra { get; set; }
        public double Tariffa { get; set; }
        public bool PensioneCompleta { get; set; }
        public bool MezzaPensione { get; set; }
        public bool Pernottamento { get; set; }
        
    }
}