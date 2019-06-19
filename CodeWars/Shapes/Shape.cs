using System;

namespace CodeWars.Shapes
{
    public abstract class Shape : IComparable
    {
        public double Area { get; set; }
        public int CompareTo(object o)
        {
            Shape p = o as Shape;
            return Area.CompareTo(p.Area);
        }
    }
}
