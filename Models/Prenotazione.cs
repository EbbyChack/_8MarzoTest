using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8MarzoTest.Models
{
    public class Prenotazione
    {
        [HiddenInput(DisplayValue = false)]
        public int IdPrenotazione { get; set; }
        [Display(Name = "Id Cliente")]
        public int IdCliente { get; set; }
        [Display(Name = "Id Camera")]
        public int IdCamera { get; set; }
        [Display(Name = "Data Prenotazione")]
        public DateTime DataPrenotazione { get; set; }
        public int Anno { get; set; }
        public DateTime Dal { get; set; }
        public DateTime Al { get; set; }
        public double Caparra { get; set; }
        public double Tariffa { get; set; }
        [Display(Name = "Pensione Completa")]
        public bool PensioneCompleta { get; set; }
        [Display(Name = "Mezza Pensione")]
        public bool MezzaPensione { get; set; }
        public bool Pernottamento { get; set; }
        
    }
}