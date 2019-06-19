namespace CodeWars.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(double doubletriangleBase, double height)
        {
            Area = doubletriangleBase * height / 2;
        }
    }
}
