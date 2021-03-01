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
    public struct Colour
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
        public int Value;
        
        public void SetValue(Color c)
        {
            R = c.R;
            G = c.G;
            B = c.B;
            A = c.A;
        }

        public Color AsColor()
        {
            return Color.FromArgb(Value);
        }

        public override string ToString()
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}@{3}", R, G, B, A);
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
