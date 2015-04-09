using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMezelf
{
    public class LijnenTrekker
    {
        
             public void TrekLijn(int lengte = 50, char teken ='-')
        {
            for (int teller = 0; teller <lengte ; teller++)
            {
                Console.Write(teken);
            }
            Console.WriteLine();
         
        }
       
    }
}
