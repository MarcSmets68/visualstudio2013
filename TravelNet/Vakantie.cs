using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    public abstract class Vakantie
    {
        public Vakantie()
        {

        }
        //public Vakantie(int boekingNr, enums.Bestemming bestemming,DateTime vertrek,DateTime terug,bool internet, int aantal = 1 )

        //{
        //    this.BoekingsNr = boekingNr;
        //    this.Bestemming = bestemming;
        //    this.VertrekDatum = vertrek;
        //    this.TerugkeerDatum = terug;
        //    this.AantalPersonen = aantal;
        //    this.InternetGewenst = internet;

        //}
        public int BoekingsNr { get; set; }
        public enums.Bestemming Bestemming { get; set; }
        public DateTime VertrekDatum { get; set; }
        private DateTime terugKeerValue;

	    public DateTime TerugkeerDatum
    	{
		get { return terugKeerValue;}
        set
        {
            terugKeerValue = value;
            if (VertrekDatum > value)
            {
                throw new TerugkeerException(BoekingsNr, VertrekDatum, TerugkeerDatum);
            }         
            }
	}

      
        
        public int AantalPersonen { get; set; }
        public bool InternetGewenst { get; set; }

        public abstract decimal BerekenVakantieprijs(); 

        
    }
}
