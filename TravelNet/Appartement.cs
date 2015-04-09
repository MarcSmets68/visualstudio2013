using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    public class Appartement:IVerblijfsType
    {
        public Appartement()
        {

        }

        //public Appartement(bool single,PrijsInfo prijsInfo,string naamVerblijf,decimal schoonmaakPrijs,bool lift, VerblijfsFormule formule)
        //{
        //    this.Formule = formule;
        //    this.ToeslagSingle = single;
        //    this.PrijsInfo = prijsInfo;
        //    this.NaamVerblijf = naamVerblijf;
        //    this.SchoonmaakPrijs = schoonmaakPrijs;
        //    this.Lift = lift;
        //}

        public decimal SchoonmaakPrijs { get; set; }

        public bool Lift { get; set; }
        private VerblijfsFormule formuleValue;
        public VerblijfsFormule Formule
        {
            get { return formuleValue; }
            set
            {
                if (BeschikbareVerblijfsFormules.Contains(value.Formule))
                {
                    formuleValue = value;
                }

                else
                {
                    throw new Exception("Verkeerde ingave formule Appartement : " + NaamVerblijf);
                }
            }
        }

        public bool ToeslagSingle { get; set; }     

        public PrijsInfo PrijsInfo { get; set; }
        
        public string NaamVerblijf { get; set; }


         public decimal BerekenVerblijfsPrijs(int aanTalDagen, VerblijfsFormule formule)
        {
            decimal prijs = 0;
            int toeslag = 0;
            if (PrijsInfo.PrijsPeriode == enums.PrijsPeriode.Week)
            {
                prijs = (PrijsInfo.BasisPrijs / 7) * aanTalDagen;
            }
            else
            {
                prijs = PrijsInfo.BasisPrijs * aanTalDagen;
            }
            if (ToeslagSingle)
                toeslag= 5 * aanTalDagen;

            decimal Totaalprijs = prijs * (1 + (decimal)formule.Factor / 100) + SchoonmaakPrijs + toeslag;
            return Totaalprijs;
        }

         public List<enums.Formule> BeschikbareVerblijfsFormules
         {
             get { return new List<enums.Formule> { enums.Formule.Ontbijt }; }
         }
    }
}
