using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelNet.Vakanties;
using TravelNet.Verblijven;

namespace TravelNet
{

    class Program
    {
        static void Main(string[] args)         
        {             
            try
            {
                List<Vakantie> alleVakanties = InvullenDataVakanties();
                VerwerkVakanties(alleVakanties);
      
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
        }       
        private static  List<Vakantie> InvullenDataVakanties()
        { 
            Hotel thuis = new Hotel
            {
                NaamVerblijf = "Villa Willa",
                Fitness = true,
                WelnessPrijs = 250,
                PrijsInfo = new PrijsInfo { BasisPrijs = 500, PrijsPeriode = enums.PrijsPeriode.Week },
                Internet = true,
                Strijkdienst = true,
                Formule = new VerblijfsFormule(enums.Formule.Volpension)
            };
           
            Appartement appart = new Appartement
            {
                NaamVerblijf = "Casa di Mama",
                PrijsInfo = new PrijsInfo { BasisPrijs = 100, PrijsPeriode = enums.PrijsPeriode.Dag },
                SchoonmaakPrijs = 50,
                Formule = new VerblijfsFormule(enums.Formule.Ontbijt)
            };

            Route eerste = new Route { VertrekPunt = "Hasselt", Eindpunt = "Chakamaka", 
                 GekozenVerblijfsType = thuis, GekozenVerblijfsFormule = thuis.Formule};
            Route tweede = new Route { VertrekPunt = "Beringen", Eindpunt = "Toremolinos", 
                 GekozenVerblijfsType = appart, GekozenVerblijfsFormule = appart.Formule };

            List<Vakantie> vakanties = new List<Vakantie>
            {
                new AutoVakantie{ BoekingsNr = 1, Bestemming = enums.Bestemming.Italië, VertrekDatum = new DateTime(2014,10,01),
                    TerugkeerDatum = new DateTime (2014,10,06), InternetGewenst = true, Routes = new List<Route>{eerste}, WagenType = enums.WagenType.EigenWagen},
                new AutoVakantie{BoekingsNr = 2,Bestemming = enums.Bestemming.Griekenland,VertrekDatum = new DateTime(2015,05,10),TerugkeerDatum = new DateTime(2015,05,24),
                    HuurPrijs = 500, InternetGewenst = false, Routes = new List<Route>{tweede, eerste}, WagenType = enums.WagenType.Camper},
                new VliegVakantie{ BoekingsNr = 3, Bestemming = enums.Bestemming.Finland,VertrekDatum = new DateTime(2015,06,15),TerugkeerDatum = new DateTime(2015,06,29), 
                    VliegTicketPrijs = 1200, InternetGewenst = true, Route = eerste},
                new Cruise{ BoekingsNr = 4, Bestemming = enums.Bestemming.Noorwegen, VertrekDatum = new DateTime(2015,08,08), TerugkeerDatum = new DateTime(2015,08,18),
                    AllInPrijs = 2300, AanlegPlaatsen = new List<string>{"ietsie","pitsie","minnie"}, Route = tweede, InternetGewenst = false},
                new AutoVakantie{}
            };
                return vakanties;    
            }
        private static void VerwerkVakanties(List<Vakantie> vakanties)
        {
            Lijn lijn = new Lijn();
            var autoVakanties =
                 from vakantie in vakanties
                 where vakantie is AutoVakantie
                 select (AutoVakantie)vakantie;
            var vliegVakanties =
                from vakantie in vakanties
                where vakantie is VliegVakantie
                select (VliegVakantie)vakantie;
            var cruiseVakanties =
                from vakantie in vakanties
                where vakantie is Cruise
                select (Cruise)vakantie;

            
            Console.BufferWidth = 130;
            Console.WindowWidth = Console.BufferWidth - 1;

            //Autovakanties
            lijn.TrekLijn(teken: '=');
            Console.WriteLine("Autovakanties");
            lijn.TrekLijn(teken: '=');
            foreach (var item in autoVakanties)
            {
                if (item.BoekingsNr != 0)
                {
                    decimal bedrag = 0;
                    Console.WriteLine(item.BoekingsNr + ". " + item.VertrekDatum.ToString("yyyy/MM/dd") + " - " + item.TerugkeerDatum.ToString("yyyy/MM/dd") + "     " + item.Bestemming);
                    Console.WriteLine();
                    int aantalDagen = (item.TerugkeerDatum - item.VertrekDatum).Days;
                    foreach (var route in item.Routes)
                    {
                        decimal verblijfsPrijs = route.GekozenVerblijfsType.BerekenVerblijfsPrijs(aantalDagen, route.GekozenVerblijfsFormule);
                        Console.WriteLine(route.VertrekPunt + " - " + route.Eindpunt + "          " + verblijfsPrijs.ToString("#,##0.00"));
                        bedrag += verblijfsPrijs;
                    }
                    Console.WriteLine("Totaalprijs : " + (bedrag + item.HuurPrijs).ToString("#,##0.00") + " EUR");
                    lijn.TrekLijn(); ;
                }
            }
            //Vliegvakanties
            Console.WriteLine("Vliegvakanties");
            lijn.TrekLijn(teken: '=');
            foreach (var item in vliegVakanties)
            {
                if (item.BoekingsNr != 0)
                {
                    int aantalDagen = (item.TerugkeerDatum - item.VertrekDatum).Days;
                    decimal verblijfsPrijs = item.Route.GekozenVerblijfsType.BerekenVerblijfsPrijs(aantalDagen, item.Route.GekozenVerblijfsFormule);
                    Console.WriteLine(item.BoekingsNr + ". " + item.VertrekDatum.ToString("yyyy/MM/dd") + " - " + item.TerugkeerDatum.ToString("yyyy/MM/dd") + "     " + item.Bestemming);
                    Console.WriteLine(item.Route.VertrekPunt + " - " + item.Route.Eindpunt + "          " + verblijfsPrijs.ToString("#,##0.00"));
                    Console.WriteLine("Totaalprijs : " + (item.VliegTicketPrijs + verblijfsPrijs).ToString("#,##0.00"));
                    lijn.TrekLijn();
                }
            }
            //Cruises
            Console.WriteLine("Cruise");
            lijn.TrekLijn(teken: '=');
            foreach (var item in cruiseVakanties)
            {
                if (item.BoekingsNr != 0)
                {
                    Console.WriteLine(item.BoekingsNr + ". " + item.VertrekDatum.ToString("yyyy/MM/dd") + " - " + item.TerugkeerDatum.ToString("yyyy/MM/dd") + "     " + item.Bestemming);
                    Console.WriteLine("Aanlegplaatsen :");
                    foreach (var aanlegplaatsen in item.AanlegPlaatsen)
                    {
                        Console.Write(aanlegplaatsen + ", ");
                    }
                    Console.WriteLine();
                    Console.WriteLine(item.Route.VertrekPunt + " - " + item.Route.Eindpunt + "          Totaalprijs : " + item.AllInPrijs.ToString("#,##0.00"));
                    lijn.TrekLijn();
                   
                }
            }
        }
      

    }
}
