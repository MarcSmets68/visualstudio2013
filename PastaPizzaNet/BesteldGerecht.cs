using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class BesteldGerecht:IBedrag
    {
        public Gerecht Gerecht {get;set;}
        public enums.Grootte Grootte { get; set; }
        public List<enums.Extra> Extra { get; set; }
       
        
        public BesteldGerecht(Gerecht gerecht,enums.Grootte grootte,List<enums.Extra> extra = null)
        {
            this.Grootte = grootte;
            this.Extra = extra;
            this.Gerecht= gerecht;
           
        }
       

        public decimal BerekenBedrag()
        {
           
                decimal bedrag = Gerecht.Prijs;
                if (enums.Grootte.groot == Grootte)
                {
                    bedrag += 3;
                }
                if (Extra != null)
                {
                    bedrag += Extra.Count;
                }
                return bedrag;
           
            
        }
        public override string ToString()
        {
            StringBuilder tekst = new StringBuilder (Gerecht+ " <" + this.Grootte + "> ");
            if (Extra != null)
            {
                foreach (var extra in Extra)
                {
                    tekst.Append("extra : " + extra.ToString() + ' ');
                }

            }
            tekst.Append("<bedrag : " + BerekenBedrag() + " euro>");
            return tekst.ToString();
        }
    }
}
