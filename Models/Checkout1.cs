using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _8MarzoTest.Models
{
    public class Checkout1
    {
        public string CF { get; set; }
        [Display(Name = "Numero Camera")]
        public int NumeroCamera { get; set; }
        public DateTime Dal { get; set; }
        public DateTime Al { get; set; }
        public double Tariffa { get; set; }
    }
}