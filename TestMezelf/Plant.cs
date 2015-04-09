using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMezelf
{
    [Serializable]
    public class Plant
    {
        private string naamValue;

        public string Naam
        {
            get { 
                return naamValue; 
            }
            set { 
                naamValue = value; 
            }
        }

        private decimal prijsValue;

        public decimal Prijs
        {
            get { 
                return prijsValue;
            }
            set { 
                prijsValue = value; 
            }
        }
        private string kleurValue;

        public string Kleur
        {
            get { 
                return kleurValue; 
            }
            set {
                kleurValue = value;
            }
        }
        private string soortValue;

        public string Soort
        {
            get { 
                return soortValue;
            }
            set { 
                soortValue = value; 
            }
        }
         public override string ToString()
        {
            return (Naam + ' ' + Kleur + ' ' + Soort + " : " + Prijs + " EUR");
        }
        

       

        public  Plant()
        {
            this.Naam = naamValue;
            this.Kleur = kleurValue;
            this.Soort = soortValue;
            this.Prijs = prijsValue;
        }
        
        
        

    }
}
