using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _8MarzoTest.Models
{
    public class Checkout3
    {
        public double Tariffa { get; set; }
        public double Caparra { get; set; }

        
        public double ColazioneInCameraPrezzo { get; set; }
        public int ColazioneInCameraQuantita { get; set; }

        public double MinibarPrezzo { get; set; }
        public int MinibarQuantita { get; set; }

        public double InternetPrezzo { get; set; }
        public int InternetQuantita { get; set; }

        public double LettoExtraPrezzo { get; set; }
        public int LettoExtraQuantita { get; set; }

        public double CullaPrezzo { get; set; }
        public int CullaQuantita { get; set; }
    }
}