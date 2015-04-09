using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace PastaPizzaNet
{
    public static class PizzaPasta
    {
    

        const string bestand = @"C:\Data\klanten.txt";
        public static bool LeesKlant(Klant klant)
        {
            string gegevens;
            using (var lees = new StreamReader(bestand))
            {
               
                while ((gegevens = lees.ReadLine()) != null) 
                {
                    var split = gegevens.Split('#');
                    if (split[1] == klant.Naam)
                    {
                       return true;
                    }               
                }
                
                return false;
            }
        }
        
        public static void SchrijfKlant(Klant klant) 
        {
            try
            {
                if (!LeesKlant(klant))
                {
                    using (var schrijf = new StreamWriter(bestand, true))
                    {
                    
                        schrijf.WriteLine(klant.SchrijfString());


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
