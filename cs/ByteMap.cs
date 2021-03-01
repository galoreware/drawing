using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Imaging;

namespace Galoreware.Drawing
{
    public class ByteMap
    {
        public Colour[,] Pixels { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public ByteMap(string filename)
        {
            Bitmap source = new Bitmap(filename);
            
            Width = source.Width;
            Height = source.Height;

            Pixels = new Colour[source.Width, source.Height];

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Pixels[x, y].SetValue(source.GetPixel(x,y));
                }
            }

            source.Dispose();
        }//NEW

    }
}
