using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMezelf
{
    public class Ingave
    {
       
        public static Plant IngaveGegevens()
        {
            string naam, kleurNaam, soortNaam;
            decimal prijs;
            Console.WriteLine("Geef de naam :");
            naam = Console.ReadLine();
            while (naam.Length < 4)
            {
                Console.WriteLine("Lengte naam min. 4 letters :");
                naam = Console.ReadLine();
            }
            naam = char.ToUpper(naam[0]) + naam.Substring(1);

            Console.WriteLine("Geef de kleur :");
            kleurNaam = Console.ReadLine();
            Console.WriteLine("Geef de soort :");
            soortNaam = Console.ReadLine();
            Console.WriteLine("Geef de prijs :");
            while (!decimal.TryParse(Console.ReadLine().Replace('.', ','), out prijs) || prijs > 100)
            {
                Console.WriteLine("Verkeerde ingave , geef de prijs : ");
            }
            return new Plant() { Naam = naam, Kleur = kleurNaam, Soort = soortNaam, Prijs = prijs };
        }
    }
}
