using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    public class VliegVakantie:Vakantie
    {
        public VliegVakantie()
        {

        }
        //public VliegVakantie(int boekingNr, enums.Bestemming bestemming, DateTime vertrek, DateTime terug, 
        //    bool internet,Route route,decimal ticketPrijs, int aantal = 1)
        //    :base(boekingNr,bestemming,vertrek,terug,internet,aantal)
        //{
        //    this.Route = route;
        //    this.VliegTicketPrijs = ticketPrijs;
        //}
        public Route Route { get; set; }

        public decimal VliegTicketPrijs { get; set; }

        
       public override decimal BerekenVakantieprijs()
        {
            int AantalDagen = (TerugkeerDatum - VertrekDatum).Days;

            decimal bedrag = VliegTicketPrijs + Route.GekozenVerblijfsType.BerekenVerblijfsPrijs(AantalDagen, Route.GekozenVerblijfsFormule);


            return bedrag;
        }
    }
}
