using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    class Bestelling : IBedrag
    {

        public Klant Klant { get; set; }
        public BesteldGerecht BesteldGerecht { get; set; }
        public Drank Drank { get; set; }
        public Dessert Dessert { get; set; }

        public Bestelling(Klant klant, int aantal, BesteldGerecht gerecht = null, Drank drank = null, Dessert dessert = null)
        {
            this.Klant = klant;
            this.BesteldGerecht = gerecht;
            this.Drank = drank;
            this.Dessert = dessert;
            this.Aantal = aantal;
            this.IsMenu = IsMenu;

        }
        private bool isMenuValue;

        public bool IsMenu
        {
            get
            {
                return isMenuValue;
            }
            set
            {
                if ((Drank == null) || (Dessert == null) || (BesteldGerecht == null))
                {
                    isMenuValue = false;
                }
                else
                {
                    isMenuValue = true;
                }
            }
        }

        private int aantalValue;

        public int Aantal
        {
            get { return aantalValue; }
            set { aantalValue = value; }
        }

        public decimal BerekenBedrag()
        {
            decimal bedrag = 0;
            if (BesteldGerecht != null)
                bedrag = BesteldGerecht.BerekenBedrag();
            if (Drank != null)
                bedrag += Drank.BerekenBedrag();
            if (Dessert != null)
                bedrag += Dessert.BerekenBedrag();
            bedrag *= Aantal;
            if (IsMenu)
            {
                bedrag *= 0.9m;
            }
            return bedrag;


        }
        public override string ToString()
        {          
                return this.BesteldGerecht.ToString();
            
        }
    }
}
