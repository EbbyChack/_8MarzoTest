using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8MarzoTest.Models
{
    public class CheckoutView
    {
        public List<Checkout1> Checkout1s { get; set; }
        public List<ServiziAggiuntivi> Checkout2s { get; set; }
        public List<double> Totale { get; set; }
    }
}