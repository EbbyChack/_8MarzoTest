using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8MarzoTest.Models
{
    public class Utente
    {
        [HiddenInput(DisplayValue = false)]
        public int IdUtente { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
       
    }
}