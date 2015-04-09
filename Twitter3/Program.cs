using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter3
{
    class Program
    {
        static void Main(string[] args)
        {
            Twitter twitter = new Twitter();
            int keuze = MaakKeuze();
            while (keuze != 4)
            {
                string naam, bericht;
                try
                {
                    switch (keuze)
                    {
                        case 1:
                            Console.WriteLine("Geef de naam :");
                            naam = Console.ReadLine();
                            Console.WriteLine("Geef het bericht :");
                            bericht = Console.ReadLine();
                            Tweet ingave = new Tweet() { Naam = naam, Bericht = bericht };
                            twitter.SchrijfTweet(ingave);
                            break;
                        case 2:
                            var tweets = twitter.AllTweets();
                            foreach (var enkel in tweets)
                            {
                                Console.WriteLine(enkel);
                            }
                            break;
                        case 3:
                            Console.WriteLine();
                            Console.WriteLine("Geef de naam :");
                            naam = Console.ReadLine();
                            Console.WriteLine();
                            var tweets2 = twitter.TweetsVan(naam);
                            if (tweets2.Count != 0)
                            {
                                foreach (var persoon in tweets2)
                                {
                                    Console.WriteLine(persoon);
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Geen tweets van {0}",naam);
                            }
                            break;
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); ;
                }
                Console.WriteLine("-----------------------------------");
                keuze = MaakKeuze();
            }
            Console.WriteLine();
            Console.WriteLine("Programma is gestopt");
            Console.WriteLine();
        }
        public static int MaakKeuze()
        {
            int keuze;
            Console.WriteLine("Gelieve een keuze te maken :");
            Console.WriteLine("1 = Een bericht plaatsen");
            Console.WriteLine("2 = Alle berichten lezen");
            Console.WriteLine("3 = Bericht lezen van specifiek persoon");
            Console.WriteLine("4 = Stoppen");
            Console.WriteLine();
            while (!int.TryParse(Console.ReadLine(), out keuze) || (keuze != 1 && keuze != 2 && keuze != 3 && keuze != 4))
            {
                Console.WriteLine("Verkeerde ingave, geef 1 , 2 , 3 , 4 in :");
            }
            return keuze;
        }

    }
}
