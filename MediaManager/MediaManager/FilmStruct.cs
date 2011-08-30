using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace MediaManager
{

    public struct Film
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public BitmapImage Image { get; set; }

        public string Rating { get; set; }
        public int ReleaseYear { get; set; }
        public string Plot { get; set; }
        public string Genres { get; set; }
        public string Directory { get; set; }
        
    }
}
