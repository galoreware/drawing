using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crRender
{
    struct Vector3D
    {
        public float X, Y, Z;
        public bool IsValid;

        public Vector3D(float x, float y, float z) { X = x; Y = y; Z = z; IsValid = true; }

        public static Vector3D operator +(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3D operator -(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3D operator * (Vector3D a, float b)
        {
            return new Vector3D(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector3D operator /(Vector3D a, float b)
        {
            Vector3D r;

            if (b == 0)
            {
                r = new Vector3D(0,0,0);
                r.IsValid = false;
            }
            else
            {
                r = new Vector3D(a.X / b, a.Y / b, a.Z / b);
            }

            return r;
        }

        public static Vector3D operator * (Vector3D a, Vector3D b)
        {
            return new Vector3D(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
        }

        public float AngleXZ()
        {
            if (Z == 0)
                return 0;

            return (float)Math.Atan2(X,Z);
        }

        public float AngleXY()
        {
            if (Z == 0)
                return 0;

            return (float)Math.Atan2(X, Y);
        }


        public float Dot(Vector3D a)
        {
            return (X * a.X) + (Y * a.Y) + (Z * a.Z);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", X, Y, Z);
        }
    }
}
