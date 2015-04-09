using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestMezelf
{
    [Serializable]
    public class Planten
    {
        private List<Plant> verzameling;
        public ReadOnlyCollection<Plant> AllesInlezen()
        {
            if (verzameling != null)
                return new ReadOnlyCollection<Plant>(verzameling);
            else
                return null;
        }
        public void PlantToevoegen(Plant plant)
        {
            if (verzameling == null)
                verzameling = new List<Plant>(); 
            verzameling.Add(plant);
        }

    }
}
