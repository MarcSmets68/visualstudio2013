using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    public class Hotel:IVerblijfsType
    {        
        public Hotel()
        {

        }
        //public Hotel(VerblijfsFormule formule,bool single,PrijsInfo prijsInfo,string naamVerblijf,
        //    bool internet,bool strijkdienst,bool fitness,decimal welness )
        //{
        //    this.Formule = formule;
        //    this.ToeslagSingle = single;
        //    this.PrijsInfo = prijsInfo;
        //    this.NaamVerblijf = naamVerblijf;
        //    this.Internet = internet;
        //    this.Strijkdienst = strijkdienst;
        //    this.Fitness = fitness;
        //    this.WelnessPrijs = welness;
        //}
        public bool Internet { get; set; }
        public bool Strijkdienst { get; set; }
        public bool Fitness { get; set; }

        private decimal? wellnessValue;

        public decimal? WelnessPrijs
        {
            get { return wellnessValue; }
            set {
                if ((value == null) || (value == 0))
                    wellnessValue = 0;
                else
                wellnessValue = value; }
        }
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
                    throw new Exception("Verkeerde ingave formule Hotel : " + NaamVerblijf);
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
              prijs = (PrijsInfo.BasisPrijs/7)*aanTalDagen  ;
            }
            else
            {
               prijs = PrijsInfo.BasisPrijs * aanTalDagen;
            }
            if (ToeslagSingle)
              toeslag= 5*aanTalDagen;

            decimal Totaalprijs = prijs * (1 + (decimal)formule.Factor / 100) + WelnessPrijs.Value+ toeslag;
            return Totaalprijs;
        }
        public List<enums.Formule> BeschikbareVerblijfsFormules
        {
            get { return new List<enums.Formule> { enums.Formule.Ontbijt, enums.Formule.Volpension }; }
        }
    }
}
