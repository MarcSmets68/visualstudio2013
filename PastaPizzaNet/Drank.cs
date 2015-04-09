using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
     
    public abstract class Drank:IBedrag

    {
        public Drank(enums.Drank naam)
        {
            this.Naam = naam;
        }
        private enums.Drank naamValue;

        public enums.Drank Naam
        {
            get { return naamValue; }
            set
            {         
                    naamValue = value;                       
            }
                
        }
        private decimal prijsValue;

        public decimal Prijs
        {
            get { return prijsValue; }
            set { prijsValue = value; }
        }
        

        public decimal BerekenBedrag()
        {           
                switch (Naam)
                {
                    case (enums.Drank.cocacola):
                    case (enums.Drank.limonade):
                    case (enums.Drank.water):
                        this.Prijs = 2;
                        break;
                    case (enums.Drank.koffie):
                    case (enums.Drank.thee):
                        this.Prijs = 2.5m;
                        break;
                }
                return this.Prijs;
        }
        public override string ToString()

        {
            return "Drank : " + this.Naam + " <" + BerekenBedrag() + " euro>" ;
        }
    }
}
