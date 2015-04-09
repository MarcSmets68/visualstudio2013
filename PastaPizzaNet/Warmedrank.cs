using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Warmedrank : Drank
    {
        private readonly static List<enums.Drank> WarmeDranken = new List<enums.Drank> { enums.Drank.koffie, enums.Drank.thee };
        public Warmedrank(enums.Drank naam)
            : base(naam)
        {
            if (WarmeDranken.Contains(naam))
            {
                this.Naam = naam;
            }
            else
            {
                throw new Exception("Selectie is geen warme drank");
            }
        }
        public override string ToString()
        {

            return base.ToString();
        }

    }
}
