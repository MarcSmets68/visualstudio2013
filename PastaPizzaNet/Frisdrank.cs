using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    
    public class Frisdrank : Drank
    {
        private readonly static List<enums.Drank> Frisdranken = new List<enums.Drank> { enums.Drank.cocacola, enums.Drank.limonade, enums.Drank.water };
        
        public Frisdrank(enums.Drank naam)
            :base(naam)
        {
            
            if(Frisdranken.Contains(naam))
            {
                this.Naam = naam;
            }       
            else
            {
                throw new Exception("Selectie is geen frisdrank");
            }            
        }



        public override string ToString()
        {

            return base.ToString();
        }
        
    }
}
