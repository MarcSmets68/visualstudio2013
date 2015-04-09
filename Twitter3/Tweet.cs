using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter3
{
    [Serializable]
   public class Tweet
    {
     
       private string berichtValue;

       public Tweet()
       {
           Tijdstip = DateTime.Now;
       }

       public string Naam { get; set; }

       public string Bericht
       {
           get
           {
              return berichtValue;
           }
           set
           {
               berichtValue = value.Length <= 140 ? value : value.Substring(0, 140);
           }
       }

      public DateTime Tijdstip{get;private set; }

       public override string ToString()
       {
          StringBuilder tweet = new StringBuilder (Naam + ':' + Bericht + ": ") ;
          TimeSpan difference = DateTime.Now - Tijdstip;
          if (difference.Days > 0)
              tweet.Append(Tijdstip.ToShortDateString());
          else if (difference.Hours > 0)
              tweet.Append("(" + difference.Hours + " uur geleden).");
          else if (difference.Minutes > 0)
              tweet.Append("(" + difference.Minutes + (difference.Minutes == 1 ? " minuut":" minuten") + " geleden).");
          else
              tweet.Append(Tijdstip.ToShortTimeString());
          return tweet.ToString();


       }
   }
}
