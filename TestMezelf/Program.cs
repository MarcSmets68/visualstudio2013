using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

namespace TestMezelf
{
    class Program
    {
        static void Main(string[] args)
        {
            PlantDatabase gegevens = new PlantDatabase();
            Planten leeg = new Planten();
            int select = 0;
          
            Console.Write("Geef de bestandsnaam van de plantendatabase op : ");
            string bestand = @"C:\Data\" + Console.ReadLine() + ".obj";
                    while (!File.Exists(bestand))
                    {
                        Console.WriteLine("{0} bestaat niet!!!",bestand);
                        Console.Write("Wenst U deze nieuwe database aan te maken? Y/N : ");
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            gegevens.SchrijfPlanten(leeg, bestand);
                        }
                        else
                        {
                            Console.WriteLine("Geef een andere bestandsnaam op of type \"stop\" om te stoppen:");
                            string keuze = Console.ReadLine();
                            if (keuze.ToUpper() == "STOP")
                            {
                                select = 8;
                                break;
                            }
                            {
                                bestand = @"C:\Data\" + keuze + ".obj";
                            }
                        }
                    }
            if (select != 8)        
            select = Selectie();
            while (select != 8)
            {
                string naam, kleurNaam, soortNaam;
                decimal prijs;
                try
                {                  
                        var alleInfo = gegevens.LeesPlanten(bestand).AllesInlezen();
                        if ((alleInfo != null) || (select == 1))
                        {
                            Console.Clear();
                            switch (select)
                            {
                                case 1:                           
                                    gegevens.SchrijfPlant(Ingave.IngaveGegevens(), bestand);
                                    break;

                                case 2:
                                    Console.WriteLine("Inhoud volledige lijst :");
                                    zoekFunctie(alleInfo.ToList());
                                    break;

                                case 3:
                                    Console.WriteLine("Geef een kleur :");
                                    kleurNaam = Console.ReadLine();
                                    var kleurgeg = alleInfo.Where(val => val.Kleur.ToUpper() == kleurNaam.ToUpper()).ToList();
                                    if (kleurgeg.Count != 0)
                                    {
                                        Console.WriteLine("Onderstaande {0} de kleur \"{1}\". ", kleurgeg.Count == 1 ? "plant heeft" : (kleurgeg.Count + " planten hebben"), kleurNaam);
                                        zoekFunctie(kleurgeg);
                                    }
                                    else
                                    {
                                        zoekFout("kleur", kleurNaam);
                                    }
                                    break;

                                case 4:
                                    Console.WriteLine("Geef een prijs :");
                                    while (!decimal.TryParse(Console.ReadLine().Replace('.', ','), out prijs))
                                    {
                                        Console.WriteLine("Verkeerd ingave, geef prijs in :");
                                    }
                                    var prijsgeg = alleInfo.Where(val => val.Prijs == prijs).ToList(); ;
                                    if (prijsgeg.Count != 0)
                                    {
                                        Console.WriteLine("Onderstaande {0} de prijs van {1} EUR",prijsgeg.Count == 1 ? "plant heeft" : (prijsgeg.Count + " planten hebben"),prijs );
                                        zoekFunctie(prijsgeg);
                                    }
                                    else
                                    {
                                        zoekFout("prijs", prijs.ToString() + " EUR");
                                    }
                                    break;

                                case 5:
                                    Console.WriteLine("Geef een soort :");
                                    soortNaam = Console.ReadLine();
                                    var soortgeg = alleInfo.Where(val => val.Soort.ToUpper() == soortNaam.ToUpper()).ToList();
                                    Console.WriteLine("Onderstaande {0} de soort \"{1}\". ", (soortgeg.Count == 1) ? "is van" : (soortgeg.Count() + "zijn van"), soortNaam);
                                    if (soortgeg.Count != 0)
                                    {
                                        zoekFunctie(soortgeg);
                                    }
                                    else
                                    {
                                      zoekFout("soort",soortNaam);
                                    }
                                    break;

                                case 6:
                                    Console.WriteLine("Geef de naam :");
                                    naam = Console.ReadLine();                                   
                                    if (gegevens.DeleteNaam(naam, bestand, alleInfo.ToList()) == "nok")
                                    {
                                        zoekFout("naam", naam);
                                    }
                                    else
                                        Console.WriteLine("Plant \"{0}\" is verwijderd in {1}.", naam, bestand);
                                    break;

                                case 7:                                
                                    if (gegevens.Backup(bestand) == "ok")
                                    {
                                        Console.WriteLine("Backup {0} geslaagd!!!", bestand);
                                        Console.WriteLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Backup {0} mislukt, probeer later eens opnieuw.",bestand);
                                    }
                                    break;


                            }
                            Console.WriteLine("Druk een toets om verder te gaan.");
                            Console.ReadLine();
                            Console.Clear();
                            select = Selectie();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Bestand bevat geen gegevens.");
                            Console.WriteLine();
                            Console.WriteLine("Druk een toets om verder te gaan.");
                            Console.ReadLine();
                            Console.Clear();
                            select = Selectie();
                            
                        }
                        Console.WriteLine();
                    }
                
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    break;
                }

            }
            Console.WriteLine("Programma gestopt!!!");
            Console.WriteLine();
        }
        public static int Selectie()
        {
            int select = 0;
            Console.WriteLine();
            Console.WriteLine("Keuzemogelijkheden :");
            Console.WriteLine("1 => nieuwe ingave plantendatabase");
            Console.WriteLine("2 => opvragen volledige plantendatabase");
            Console.WriteLine("3 => opvragen planten per kleur");
            Console.WriteLine("4 => opvragen planten per prijs");
            Console.WriteLine("5 => opvragen planten per soort");
            Console.WriteLine("6 => verwijderen plant");
            Console.WriteLine("7 => backup plantendatabase");
            Console.WriteLine("8 => stoppen");
            Console.WriteLine();
            Console.Write("Geef je keuze in : ");

            while (!int.TryParse(Console.ReadLine(), out select) || select <= 0 || select > 8)
            {
                Console.WriteLine("Verkeerde ingave, geef 1 , 2 , 3 , 4 , 5, 6, 7 of 8 in :");
            }
            Console.WriteLine();
            return select;
        }
        public static void zoekFout(string type, string naam)
        {

            Console.WriteLine();
            Console.WriteLine("De {0} \"{1}\" is niet teruggevonden in de lijst.", type, naam);
            Console.WriteLine();

        }
        public static void zoekFunctie(List<Plant> gegevens)
        {
            LijnenTrekker lijn = new LijnenTrekker();
            lijn.TrekLijn(teken: '=');
            foreach (var visual in gegevens)
            {
                Console.WriteLine(visual);
            }
            lijn.TrekLijn();
        }
       
    }
}
