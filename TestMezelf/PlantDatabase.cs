using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace TestMezelf
{
    [Serializable]
    public class PlantDatabase
    {
        public void SchrijfPlant(Plant plant,string bestand)
        {
            Planten planten;
            if (File.Exists(bestand))
            {
               planten = LeesPlanten(bestand);
            }
            else
                planten = new Planten();
            planten.PlantToevoegen(plant);
            SchrijfPlanten(planten,bestand);

        }
        public void SchrijfPlanten (Planten input, string bestand)
        {
            try
            {
                using (var schrijfopdracht = File.Open(bestand,FileMode.OpenOrCreate))
                {
                    var schrijf = new BinaryFormatter();
                    schrijf.Serialize(schrijfopdracht, input);
                }
            }
            catch (IOException)
            {
                
                throw new Exception("Kan bestand niet schrijven.");
            }
            catch (SerializationException)
            {
                throw new Exception("Fout bij het serialiseren.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Planten LeesPlanten(string bestand)
        {
            try
            {
                if (File.Exists(bestand))
                {
                    using (var leesopdracht = File.Open(bestand, FileMode.Open, FileAccess.Read))
                    {
                        var lees = new BinaryFormatter();
                        return (Planten)lees.Deserialize(leesopdracht);
                    }
                }
              
                    else
                    {                    
                        throw new Exception("Het bestand \"" + bestand + "\" is niet gevonden!");;
                    }
                }
            catch (IOException)
            {
                
                throw new Exception("Kan bestand niet lezen.");
            }
            catch (SerializationException)
            {
                throw new Exception("Fout bij het deserialiseren");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
      

        public string DeleteNaam(string naam, string bestand, List<Plant> alleInfo)
        {
            Planten planten = new Planten();
            var controle = alleInfo.Where(val => val.Naam.ToUpper() == naam.ToUpper());
            if (controle.Count() != 0)
            {
                var nietteverwijderenPlanten = LeesPlanten(bestand).AllesInlezen().Where(val => val.Naam.ToUpper() != naam.ToUpper());
                foreach (var plant in nietteverwijderenPlanten)
                {
                    planten.PlantToevoegen(plant);

                }
                SchrijfPlanten(planten, bestand);              
                return "ok";
            }
            else
            {
                return "nok";
                
            }
        }
        public string Backup(string bestand)
        {
            
            var inlezing = LeesPlanten(bestand);
            bestand = @"C:\Backup\Planten" + DateTime.Now.ToString("yyyyMMddHmm") + ".obj";
            SchrijfPlanten(inlezing, bestand);
            if (File.Exists(bestand))
            {
                return "ok";
            }
            else
            {
                return "nok";
            }
            
           
            
        }
    }
}
