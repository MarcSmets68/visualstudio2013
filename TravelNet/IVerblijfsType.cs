using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Verblijven
{
    public interface IVerblijfsType
    {
        List<enums.Formule> BeschikbareVerblijfsFormules { get; }
        bool ToeslagSingle { get; set; }

        PrijsInfo PrijsInfo { get; set; }

        string NaamVerblijf { get; set; }

        decimal BerekenVerblijfsPrijs(int aanTalDagen, VerblijfsFormule formule);


    }
}
