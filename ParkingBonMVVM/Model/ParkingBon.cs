using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingBonMVVM.Model
{
    public class ParkingBon
    {
        public ParkingBon()
        {
            Datum = DateTime.Now;
            Aankomst = DateTime.Now.ToShortTimeString();
            Vertrek = Aankomst;
            Bedrag = "0 €";
        }
        public DateTime Datum { get; set; }
        public string Aankomst { get; set; }
        public string Vertrek { get; set; }
        public string Bedrag { get; set; }
    }
}
