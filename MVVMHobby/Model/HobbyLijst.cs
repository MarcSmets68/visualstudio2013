using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MVVMHobby.Model
{
   public  class HobbyLijst
    {
       private List<Hobby> hobbies = new List<Hobby>();
       public List<Hobby> Hobbies
       {
           get
           {
               return hobbies;
           }
           set
           {
               hobbies = value;
           }
       }
       public HobbyLijst()
       {
           hobbies.Add(new Hobby("sport", "voetbal",
          new BitmapImage(new Uri(@"\Model\images\voetbal.jpg", UriKind.Relative))));
           hobbies.Add(new Hobby("sport", "atletiek",
           new BitmapImage(new Uri(@"\Model\images\atletiek.jpg", UriKind.Relative))));
           hobbies.Add(new Hobby("sport", "basketbal",
           new BitmapImage(new Uri(@"\Model\images\basketbal.jpg",
           UriKind.Relative))));
           hobbies.Add(new Hobby("sport", "tennis",
           new BitmapImage(new Uri(@"\Model\images\tennis.jpg", UriKind.Relative))));
           hobbies.Add(new Hobby("sport", "turnen",
           new BitmapImage(new Uri(@"\Model\images\turnen.jpg", UriKind.Relative))));
           hobbies.Add(new Hobby("muziek", "trompet",
           new BitmapImage(new Uri(@"\Model\images\trompet.jpg", UriKind.Relative))));
           hobbies.Add(new Hobby("muziek", "drum",
           new BitmapImage(new Uri(@"\Model\images\drum.jpg", UriKind.Relative))));
           hobbies.Add(new Hobby("muziek", "gitaar",
           new BitmapImage(new Uri(@"\Model\images\gitaar.jpg", UriKind.Relative))));
           hobbies.Add(new Hobby("muziek", "piano",
           new BitmapImage(new Uri(@"\Model\images\piano.jpg", UriKind.Relative)))); 
       }
    }
}
