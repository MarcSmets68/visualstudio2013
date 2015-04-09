using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet
{
     public class TerugkeerException : Exception
     { 
         
         public TerugkeerException(int boekingsNr,DateTime vertrekDatum, DateTime terugkeerDatum)
         {
             Console.BufferWidth = 130;
             Console.WindowWidth = Console.BufferWidth - 1;
             Console.WriteLine("Reis met boekingsnr : " + boekingsNr + ": terugkeerdatum(" + terugkeerDatum.ToString("yyyy/MM/dd")
                    + ") moet later zijn dan de vertrekdatum (" + vertrekDatum.ToString("yyyy/MM/dd") + ")!");
         }

    }
}
