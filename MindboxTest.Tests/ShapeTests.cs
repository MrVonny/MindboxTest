using System.Collections.Generic;
using MindboxTest.AreaMeter.Shapes;
using NUnit.Framework;

namespace MindboxTest.Tests
{
    public class ShapeTests
    {
        [Test]
        public void BasicAcceptance()
        {
            List<Shape> shapes = new();
            var circle = new Circle(5);
            shapes.Add(circle);
            var triangle = new Triangle(3, 4, 5);
            shapes.Add(triangle);
            Assert.Multiple(() =>
            {
                Assert.That(shapes[0].Square, Is.EqualTo(circle.Square));
                Assert.That(shapes[1].Square, Is.EqualTo(triangle.Square));
            });
        }
    }
}