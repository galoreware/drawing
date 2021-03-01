using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

using System.Drawing;
using System.Drawing.Imaging;

namespace Galoreware.Drawing
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Pixel
    {
        [FieldOffset(0)]
        public byte R;
        [FieldOffset(1)]
        public byte G;
        [FieldOffset(2)]
        public byte B;
        [FieldOffset(3)]
        public byte A;

        [FieldOffset(0)]
        public int Value;

        [FieldOffset(4)]
        public int X;

        [FieldOffset(8)]
        public int Y;

        public void SetValue(Color c, int x = 0, int y = 0)
        {
            X = x;
            Y = y;

            R = c.R;
            G = c.G;
            B = c.B;
            A = c.A;
        }

        public override string ToString()
        {
            return string.Format("{0},{1} - #{2:X2}{3:X2}{4:X2}@{5}", X, Y, R, G, B, A);
        }

        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(Pixel a, Pixel b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(Pixel a, Pixel b)
        {
            return a.Value != b.Value;
        }
    }
}
