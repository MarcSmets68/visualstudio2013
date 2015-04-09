using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Dessert: IBedrag
    {
        public Dessert(enums.Dessert naam)
        {
            this.Naam = naam;
        }
        private enums.Dessert naamValue;

        public enums.Dessert Naam
        {
            get { return naamValue; }
            set { naamValue = value; }
        }
        

        public decimal Prijs { get; set; }
            
        public decimal BerekenBedrag()
        {
           
                switch (Naam)
                {
                    case (enums.Dessert.Tiramisu):
                    case (enums.Dessert.Ijs):
                        this.Prijs = 3;
                        break;
                    case (enums.Dessert.Cake):
                        this.Prijs = 2;
                        break;
                }
                return this.Prijs;
         
        }
        public override string ToString()
        {
            return "Dessert : " + this.Naam + " <" + BerekenBedrag() + " euro>";
        }
    }
}
