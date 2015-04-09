using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PastaPizzaNet
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Klant k1 = new Klant("Jan Janssen",1);
                PizzaPasta.SchrijfKlant(k1);      
                Klant k2 = new Klant("Piet Peters",2);
                PizzaPasta.SchrijfKlant(k2);
                Klant k3 = new Klant();
                var order = new List<Bestelling>
                {new Bestelling(
                    k1,2,new BesteldGerecht(new Pizza("Pizza Margharita",new List<string>{"Tomatensaus","Mozarella"}),
                        enums.Grootte.groot,new List<enums.Extra>{enums.Extra.kaas,enums.Extra.look}),
                        new Frisdrank(enums.Drank.cocacola),new Dessert(enums.Dessert.Ijs)),
                 new Bestelling(
                    k2,1,new BesteldGerecht(new Pizza("Pizza Margharita",new List<string>{"Tomatensaus","Mozarella"}),
                        enums.Grootte.klein),
                        new Frisdrank(enums.Drank.water),new Dessert(enums.Dessert.Tiramisu)),
                 new Bestelling(
                    k2,1,new BesteldGerecht(new Pizza("Pizza Napoli",new List<string>{"Tomatensaus","Mozarella", " Ansjovis","Kappers", "Olijven"},10),
                        enums.Grootte.groot),
                        new Warmedrank(enums.Drank.thee),new Dessert(enums.Dessert.Ijs)),
                 new Bestelling(
                    k3,1,new BesteldGerecht(new Pasta("Lasagna",15),
                        enums.Grootte.klein,new List<enums.Extra>{enums.Extra.look})),
                 new Bestelling(
                     k1,1,new BesteldGerecht( new Pasta("Spaghetti Carbonara",13,"spek, roomsaus en parmezaanse kaas"),enums.Grootte.klein),
                     new Frisdrank(enums.Drank.cocacola)),
                 new Bestelling(
                     k2,1, new BesteldGerecht(new Pasta("Spaghetti Bolognese",12,"met gehaktsaus"),enums.Grootte.groot,
                         new List<enums.Extra>{enums.Extra.kaas}),new Frisdrank(enums.Drank.cocacola),new Dessert(enums.Dessert.Cake)),
                 new Bestelling(k2,3,drank:new Warmedrank(enums.Drank.koffie)),
                 new Bestelling(k1,1,dessert:new Dessert(enums.Dessert.Tiramisu))
                      
                };
                Console.BufferWidth = 130;
                Console.WindowWidth = Console.BufferWidth - 1;
                foreach (var item in order)
                {
                    Console.WriteLine("Bestelling {0}:", (order.IndexOf(item) + 1));
                    Console.WriteLine(item.Klant);
                    if (item.BesteldGerecht != null)
                    Console.WriteLine(item);
                    if (item.Drank != null)
                        Console.WriteLine(item.Drank);
                    if (item.Dessert != null)
                        Console.WriteLine(item.Dessert);
                    Console.WriteLine("Aantal : " + item.Aantal);
                    Console.WriteLine("Totaal bedrag : " + item.BerekenBedrag() + " euro");
                    Console.WriteLine();
                    for (int i = 0; i < 50; i++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
