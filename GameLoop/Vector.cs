using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameLoop
{
    [StructLayout(LayoutKind.Sequential)]


    public struct Vector
    {

        //gives a definition to zero vector 

        public static readonly Vector Zero = new Vector(0, 0, 0);
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double Length()
        {
            return Math.Sqrt(LengthSquared());
        }

        public double LengthSquared()
        {
            return (X * X + Y * Y + Z * Z);
        }

        public bool Equals (Vector v)
        {
            return (X == v.X) && (Y == v.Y) && (Z == v.Z);
        }

        public override int GetHashCode()
        {
            return (int)X ^ (int)Y ^ (int)Z;
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            // If they're the same object or both null, return.
            if (System.Object.ReferenceEquals(v1, v2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (v1 == null || v2 == null)
            {
                return false;
            }

            return v1.Equals(v2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                return Equals((Vector)obj);
            }
            return base.Equals(obj);
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !v1.Equals(v2);
        }

        //addition vectors

        public Vector Add(Vector r)
        {
            return new Vector(X + r.X, Y + r.Y, Z + r.Z);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return v1.Add(v2);
        }

        //subtraction vector

        public Vector Subtract(Vector r)
        {
            return new Vector(X - r.X, Y - r.Y, Z - r.Z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1.Subtract(v2);
        }

        //multiplication vector

        public Vector Multiply(double v)
        {
            return new Vector(X * v, Y * v, Z * v);
        }

        public static Vector operator *(Vector v, double s)
        {
            return v.Multiply(s);
        }
        //determine if character is within a range by normalizing to 1 it can be in range or out of 1 range etc.
        public Vector Normalise(Vector v)
        {
            double r = v.Length();
            if (r != 0.0)               //division by zero is a no-no!
            {
                return new Vector(v.X / r, v.Y / r, v.Z / r);   
            }
            else
            {
                return new Vector(0, 0, 0);
            }
        }

        //dot product to determine what side of wall and if characters facing each other
        public double DotProduct(Vector v)
        {
            return (v.X * X) + (Y * v.Y) + (Z * v.Z);
        }

        public static double operator *(Vector v1, Vector v2)
        {
            return v1.DotProduct(v2);
        }

        //find the normal to a plane used to direct an objects movement forwar etc.

        public Vector CrossProduct(Vector v)
        {
            double nx = Y * v.Z - Z * v.Y;
            double ny = Z * v.X - X * v.Z;
            double nz = X * v.Y - Y * v.X;
            return new Vector(nx, ny, nz);
        }

        //makes it easier to get to the values
        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}, Z:{2}", X, Y, Z);
        }









    }
}
