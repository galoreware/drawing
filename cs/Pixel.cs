using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace GaloreWare.Drawing
{
    /// <summary>
    /// 32-bit Pixel
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Pixel
    {
        [FieldOffset(2)]
        public byte R;

        [FieldOffset(1)]
        public byte G;

        [FieldOffset(0)]
        public byte B;

        [FieldOffset(3)]
        public byte A;

        [FieldOffset(0)]
        public int Value = 0x00000000;//Transparent

        public Pixel(byte r, byte g, byte b, byte a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public Pixel(int data)
        {
            //https://stackoverflow.com/questions/6700307/c-sharp-read-rgb-from-a1r5g5b5-image-type/6701049#6701049

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
            return string.Format("#{0:X2}{1:X2}{2:X2} @{3}", R, G, B, A);
        }

        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(Colour a, Colour b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(Colour a, Colour b)
        {
            return a.Value != b.Value;
        }
    }
}
