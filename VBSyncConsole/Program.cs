using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace VBSyncConsole
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Method Main is gestart...");
            Start();
            Console.WriteLine("Terug in Method Main");
            Console.WriteLine("Druk een toets.");
            Console.WriteLine();
            Console.ReadLine();
        }
        static async void Start()
        {
            string tekst = await DoeIetsAsync();
            Console.WriteLine(tekst);
        }
        static async Task<string> DoeIetsAsync()
        {
           
            Console.WriteLine("Bezig met taak...DoeIets");
            await Task.Delay(5000);
            return ("De taak is afgewerkt.");
            
        }
    }
}
