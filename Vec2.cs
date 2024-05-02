using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaBall2_0
{
    public class Vec2
    {
        public float X, Y;
        public Vec2(double X, double Y)
        {
            this.X = (float)X;
            this.Y = (float)Y;
        }
        public Vec2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public static Vec2 operator -(Vec2 v)
        {
            return new Vec2(-v.X, -v.Y);
        }
        public static Vec2 operator +(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X + b.X, a.Y + b.Y);
        }
        public static Vec2 operator +(Vec2 a, float b)
        {
            return new Vec2(a.X + b, a.Y + b);
        }
        public static Vec2 operator -(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X - b.X, a.Y - b.Y);
        }
        public static Vec2 operator -(Vec2 a, float b)
        {
            return new Vec2(a.X - b, a.Y - b);
        }
        public static Vec2 operator *(float a, Vec2 b)
        {
            return new Vec2(a * b.X, a * b.Y);
        }
        public static Vec2 operator *(Vec2 b, float a)
        {
            return new Vec2(a * b.X, a * b.Y);
        }
        public static Vec2 operator /(Vec2 b, float a)
        {
            return new Vec2(b.X / a, b.Y / a);
        }
        public static Vec2 operator /(float a, Vec2 b)
        {
            return new Vec2(b.X / a, b.Y / a);
        }
        public float MagSqr()
        {
            return (X * X) + (Y * Y);
        }
        public float Length()
        {
            return (float)Math.Sqrt((X * X) + (Y * Y));
        }
        public float Distance(Vec2 a)
        {
            return (float)Math.Sqrt(Math.Pow(X - a.X, 2) + Math.Pow(Y - a.Y, 2));
        }

    }
}
