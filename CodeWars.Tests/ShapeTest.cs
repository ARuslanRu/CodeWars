using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeWars.Shapes;

namespace CodeWars.Tests
{
    [TestClass]
    public class ShapeTest
    {
        #region <6kyu>
        /// <summary>
        /// Although shapes can be very different by nature, they can be sorted by the size of their area.
        /// Task:
        /// Create different shapes that can be part of a sortable list.The sort order is based on the size of their respective areas:
        /// The area of a Square is the square of its side
        /// The area of a Rectangle is width multiplied by height
        /// The area of a Triangle is base multiplied by height divided by 2
        /// The area of a Circle is the square of its radius multiplied by π
        /// The area of a CustomShape is given
        /// The default sort order of a list of shapes is ascending on area size:
        /// var side = 1.1234D;
        /// var radius = 1.1234D;
        /// var base = 5D;
        /// var height = 2D;
        /// var shapes = new List<Shape>{ new Square(side), new Circle(radius), new Triangle(base, height) };
        /// shapes.Sort();
        /// Use the correct π constant for your circle area calculations:
        /// System.Math.PI
        /// </summary>
        [TestMethod]
        public void ShapesAreSortableOnArea()
        {
            // Arrange
            double width, height, triangleBase, side, radius, area;
            Random random = new Random((int)DateTime.UtcNow.Ticks);

            var expected = new List<Shape>();

            area = 1.1234;
            expected.Add(new CustomShape(area));

            side = 1.1234;
            expected.Add(new Square(side));

            radius = 1.1234;
            expected.Add(new Circle(radius));

            triangleBase = 5;
            height = 2;
            expected.Add(new Triangle(triangleBase, height));

            height = 3;
            triangleBase = 4;
            expected.Add(new Triangle(triangleBase, height));

            width = 4;
            expected.Add(new Rectangle(width, height));

            area = 16.1;
            expected.Add(new CustomShape(area));

            var actual = expected.OrderBy(x => random.Next()).ToList();

            // Act
            actual.Sort();

            // Assert
            for (var i = 0; i < 5; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }

        #endregion
    }
}
