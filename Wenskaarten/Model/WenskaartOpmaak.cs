using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Wenskaarten.Model
{
    public class WenskaartOpmaak
    {
        public string Naam { get; set; }
        public BitmapImage Kaart { get; set; }

        public WenskaartOpmaak()
        {

        }
        public WenskaartOpmaak(string nNaam, BitmapImage nKaart)
        {
            Naam = nNaam;
            Kaart = nKaart;
        }
    }
}
