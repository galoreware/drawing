using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GaloreWare.IO;

namespace GaloreWare.Drawing.Bitmaps
{
    /// <summary>
    /// 24-Bit Hardcoded Windows Bitmap Generator
    /// </summary>
    public class BmpImage
    {
        Binary _data;
        int _w, _h, _row_size, _data_size;

        public int Width { get { return _w; } }
        public int Height { get { return _h; } }

        public BmpImage(string fileName)
        {
            _data = new Binary(fileName);

            _w = _data.ReadInt32(0x12);
            _h = _data.ReadInt32(0x16);

            _row_size = (int)Math.Ceiling(((float)_w * 3.0f) / 8.0) * 8;
        }

        public BmpImage(int w, int h)
        {
            _w = w;
            _h = h;
            _row_size = (int)Math.Ceiling(((float)w * 3.0f) / 8.0) * 8;

            _data_size = _row_size * h;

            _data = new Binary(56);

            //BMP HEADER (DOESN'T CHANGE AT ALL)
            _data.WriteASCII(0x0, "BM", 2);//BITMAP TYPE - BM = WINDOWS BITMAP
            _data.WriteInt32(0xA, 54);//DATA OFFSET

            //DIB HEADER (DOESN'T CHANGE AT ALL)
            _data.WriteInt32(0xE, 40);//HEADER SIZE
            _data.WriteInt16(0x1A, 1);//PLANES, ALWAYS 1
            _data.WriteInt16(0x1C, 24);//BITS PER PIXEL

            //VARIABLE VALUES
            _data.WriteInt32(0x12, w);//SET WIDTH
            _data.WriteInt32(0x16, -h);//SET HEIGHT

            _data.WriteInt32(0x2, 54 + _data_size);//DATA OFFSET
            _data.WriteInt32(0x22, _data_size);//DATA SIZE

            _data.Fill(54, _data_size);//SET DEFULT VALUES (BLACK)
        }//NEW

        public void DrawDiagonal()
        {
            for (int y = 0; y < _h; y++)
            {
                for (int x = 0; x < _w; x++)
                {
                    if (x == y)
                        SetPixel(x, y, 255, 0, 0);
                }
            }
        }

        public void Save(string fileName)
        {
            _data.Save(fileName);
        }

        public byte Debug_GetMax()
        {
            int tmp = 0;
            int data;

            for (int i = 0; i < _data_size; i++)
            {
                data=_data[54+i];
                tmp = data > tmp ? data : tmp;
            }

            return (byte)tmp;
        }

        public byte Debug_GetMin()
        {
            int tmp = 255;
            int data;

            for (int i = 0; i < _data_size; i++)
            {
                data = _data[54 + i];
                tmp = data < tmp ? data : tmp;
            }

            return (byte)tmp;
        }

        public byte[] GetBGRPixel(int x, int y)
        {
            int offset = 54 + 3 * x + _row_size * (y);
            byte[] pixel = _data[offset, 3];
            return pixel;
        }

        public void SetPixel(int x, int y, byte r, byte g, byte b)
        {
            int offset = 54 + 3 * x + _row_size * (_h - y);
            byte[] pixel = { g, b, r };
            _data.Write(offset, pixel, 3);
        }//SETPIXEL

        public void SetPixels(Pixel[] pixels)
        {
            int offset = 54;
            byte[] buffer = new byte[3];
            
            foreach (Pixel pixel in pixels)
            {
                _data.Write(offset, pixel.GetRGBBytes(), 3);
                offset += 3;
            }
        }//SET PIXELS

        public void SetData(byte[] data)
        {
            _data.Write(54, data, data.Length);
        }


    }
}
