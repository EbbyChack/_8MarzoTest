﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8MarzoTest.Models
{
    public class Cliente
    {
        [HiddenInput(DisplayValue = false)]
        public int IdCliente { get; set; }
        public string CF { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
    }
}