using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    public class VerblijfsFormule
    {
        public VerblijfsFormule(enums.Formule naam)
        { 
            this.Formule = naam;
            
        }
        private enums.Formule naamValue;
        public enums.Formule Formule
        {
            get { return naamValue; }
            set { naamValue = value; }
        }
        private int factorValue;

        public int Factor
        {
            get {    
            switch(this.Formule)
            {
                case enums.Formule.Ontbijt:
                factorValue = 10;
                return factorValue;
                case enums.Formule.HalfPension:
                factorValue = 20;
                return factorValue;
                case enums.Formule.Volpension:
                factorValue = 50;
                return factorValue;
                default:
                factorValue = 0;
                return factorValue;       
            }
            }
           
        }
      
    }
}
