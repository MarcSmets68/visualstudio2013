using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    public class PrijsInfo
    {
        public PrijsInfo()
        {

        }
        public PrijsInfo(decimal basisPrijs,enums.PrijsPeriode prijsPeriode)
        {
            this.BasisPrijs = basisPrijs;
            this.PrijsPeriode = prijsPeriode;
        }
        public decimal BasisPrijs { get; set; }

        public enums.PrijsPeriode PrijsPeriode { get; set; }

    }
}
