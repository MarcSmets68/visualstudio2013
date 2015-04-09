using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    public class Cruise:Vakantie
    {
        public Cruise()
        {

        }
       
        //public Cruise(int boekingNr, enums.Bestemming bestemming, DateTime vertrek, DateTime terug,
        //    bool internet, Route route, List<String> aanlegPlaatsen, int aantal = 1)
        //    :base(boekingNr,bestemming,vertrek,terug,internet,aantal)
        //{
        //    this.AanlegPlaatsen = aanlegPlaatsen;
        //    this.Route = route;
        //}
        public Route Route { get; set; }
        public List<String> AanlegPlaatsen { get; set; }
        public decimal AllInPrijs { get; set; }
        public override decimal BerekenVakantieprijs()
        {
            return AllInPrijs;
        }

    }

}
