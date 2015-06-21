using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Wenskaarten.Model
{
    public class WenskaartOpmaak
    {
        public string Wens { get; set; }
        public BitmapImage Figuur { get; set; }
        public string FontGrootte { get; set; }
        public ImageBrush BitmapImageBrush { get; set; }
    }
}
