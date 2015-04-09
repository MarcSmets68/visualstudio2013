using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelNet.Vakanties
{
    public class Route
    {
        public Route()
        {

        }
        //public Route(string vertrek,string eind,Verblijven.IVerblijfsType gekozen,Verblijven.VerblijfsFormule formule)
        //{
        //    this.VertrekPunt = vertrek;
        //    this.Eindpunt = eind;
        //    this.GekozenVerblijfsType = gekozen;
        //    this.GekozenVerblijfsFormule = formule;
        //}
        public string VertrekPunt { get; set; }
        public string Eindpunt { get; set; }
        public Verblijven.IVerblijfsType GekozenVerblijfsType { get; set; }
        public Verblijven.VerblijfsFormule GekozenVerblijfsFormule { get; set; }

    }
}
