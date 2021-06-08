using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaloreWare.Drawing
{
    public struct Pixel
    {
        public byte R, G, B, A;
        public Pixel(byte r, byte g, byte b, byte a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public Pixel(short data)
        {
            https://stackoverflow.com/questions/6700307/c-sharp-read-rgb-from-a1r5g5b5-image-type/6701049#6701049

            bool alpha = (data & 0x8000) > 0;
            B = (byte)(((data & 0x7C64) >> 10) * 8.226);
            G = (byte)(((data & 0x3E0) >> 5) * 8.226);
            R = (byte)(((data & 0x001F)) * 8.226);
            A = (byte)((alpha ? 255 : 0) * 8.226);
        }

        public byte[] GetRGBBytes()
        {
            return new byte[] { R,G,B };
        }

        public override string ToString()
        {
            return string.Format("{0},{1}{2} @ {3}", R, G, B, A);
        }
    }
}
