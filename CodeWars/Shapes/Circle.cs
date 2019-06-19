using System;

namespace CodeWars.Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Area = Math.PI * radius * radius;
        }
    }
}
