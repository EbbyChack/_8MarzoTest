using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8MarzoTest.Models
{
    public class ServiziAggiuntivi
    {
        [HiddenInput(DisplayValue = false)]
        public int IdServizio { get; set; }

        [Display(Name = "Id Prenotazione")]
        public int IdPrenotazione { get; set; }

        [Display(Name = "Colazione in camera")]
        public bool ColazioneInCamera { get; set; }
        [Display(Name = "Prezzo")]
       
        public decimal ColazioneInCameraPrezzo { get; set; } = 10.00m;
        [Display(Name = "Data")]
        public DateTime ColazioneInCameraData { get; set; }
        [Display(Name = "Quantità")]
        public int ColazioneInCameraQuantita{ get; set; }

        [Display(Name = "Mini bar")]
        public bool MiniBar { get; set; }
        [Display(Name = "Prezzo")]
        public decimal MiniBarPrezzo { get; set; } = 20.00m;
        [Display(Name = "Data")]
        public DateTime MiniBarData { get; set; }
        [Display(Name = "Quantità")]
        public int MiniBarQuantita { get; set; }

        public bool Internet { get; set; }
        [Display(Name = "Prezzo")]
        public decimal InternetPrezzo { get; set; } = 30.00m;
        [Display(Name = "Data")]
        public DateTime InternetData { get; set; }
        [Display(Name = "Quantità")]
        public int InternetQuantita { get; set; }

        [Display(Name = "Letto extra")]
        public bool LettoExtra { get; set; }
        [Display(Name = "Prezzo")]
        public decimal LettoExtraPrezzo { get; set; } = 40.00m;
        [Display(Name = "Data")]
        public DateTime LettoExtraData { get; set; }
        [Display(Name = "Quantità")]
        public int LettoExtraQuantita { get; set; }

        public bool Culla { get; set; }
        [Display(Name = "Prezzo")]
        public decimal CullaPrezzo { get; set; } = 20.00m;
        [Display(Name = "Data")]
        public DateTime CullaData { get; set; }
        [Display(Name = "Quantità")]
        public int CullaQuantita { get; set; }
    }
}