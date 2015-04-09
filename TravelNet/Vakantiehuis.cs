using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    public class Vakantiehuis:IVerblijfsType
    {
        public Vakantiehuis()
        {

        }
        public Vakantiehuis(bool single,PrijsInfo prijsInfo,string naamVerblijf,
            decimal schoonmaak,decimal linnengoed, VerblijfsFormule formule)
        {
            this.Formule = formule;
            this.ToeslagSingle = single;
            this.PrijsInfo = prijsInfo;
            this.NaamVerblijf = naamVerblijf;
            this.SchoonmaakPrijs = schoonmaak;
            this.LinnengoedPrijs = linnengoed;

        }
        public decimal SchoonmaakPrijs { get; set; }
        public decimal LinnengoedPrijs { get; set; }

        private VerblijfsFormule formuleValue;

        public VerblijfsFormule Formule
        {
            get { return formuleValue; }
            set {
                if (BeschikbareVerblijfsFormules.Contains(value.Formule))
                {
                    formuleValue = value;
                }
                else
                {
                    throw new Exception("Verkeerde ingave formule Vakantiehuis : " + NaamVerblijf);
                }
            }
        }
        public bool ToeslagSingle { get; set; }

        public PrijsInfo PrijsInfo { get; set; }

        public string NaamVerblijf { get; set; }

         public decimal BerekenVerblijfsPrijs(int aanTalDagen,VerblijfsFormule formule)
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
                toeslag = 5 * aanTalDagen;

            decimal Totaalprijs = prijs * (1 + (decimal)formule.Factor / 100) + SchoonmaakPrijs + LinnengoedPrijs + toeslag;
            return Totaalprijs;
        }



         public List<enums.Formule> BeschikbareVerblijfsFormules
         {
             get
             { 
                 return new List<enums.Formule>{enums.Formule.Ontbijt,enums.Formule.HalfPension};
             }
         }
         
    }
}
