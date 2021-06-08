using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GaloreWare.IO;
using GaloreWare.Drawing;

namespace GaloreWare.Drawing.Bitmaps
{
    public class A1R5G5B5Image
    {
        Pixel[] _pixels;
        //ByteWrite _data;
        int _w, _h;

        public int Width { get { return _w; } }
        public int Height { get { return _h; } }
        public Pixel[] Pixels { get { return _pixels; } }

        public A1R5G5B5Image(int w, int h)
        {
            _w = w;
            _h = h;
            _pixels = new Pixel[_w * _h];
        }

        public void Read(ByteAccess buffer, int offset = 0)
        {
            Pixel tmp = new Pixel(0, 0, 0, 255);
            
            short data;
            
            int i=0;

            for (int y = 0; y < _h; y++)
            {
                for (int x = 0; x < _w; x++)
                {
                    data = buffer.GetInt16((i * 2));
                    _pixels[i] = new Pixel(data);
                    i++;
                }
            }
        }
    }
}
