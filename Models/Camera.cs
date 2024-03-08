using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8MarzoTest.Models
{
    public class Camera
    {
        [HiddenInput(DisplayValue = false)]
        public int IdCamera { get; set; }
        public int NumeroCamera { get; set; }
        public string Descrizione { get; set; }
        public string Tipologia { get; set; }
    }
}