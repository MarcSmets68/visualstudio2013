using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    public class AutoVakantie:Vakantie
    {
        public AutoVakantie()
        {
           
        }
        //public AutoVakantie(int boekingNr, enums.Bestemming bestemming, DateTime vertrek, DateTime terug, 
        //    bool internet,List<Route> routes,decimal huurprijs, int aantal, enums.WagenType wagenType)
        //    :base(boekingNr,bestemming,vertrek,terug,internet,aantal)
        //{
        //    this.HuurPrijs = huurprijs;
        //    this.Routes = routes;
        //    this.WagenType = wagenType;
        //}
        public List<Route> Routes { get; set; }
        public enums.WagenType WagenType { get; set; }

        private decimal huurPrijsValue;

        public decimal HuurPrijs
        {
            get { return huurPrijsValue; }
            set
            {
                huurPrijsValue = value;
            }
        }
        public override decimal BerekenVakantieprijs()
        {

            if (enums.WagenType.EigenWagen == WagenType)
                HuurPrijs = 0;
            return HuurPrijs; 
        }
        
        
    }
}
