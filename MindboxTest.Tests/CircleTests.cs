using System;
using MindboxTest.AreaMeter.Shapes;
using NUnit.Framework;

namespace MindboxTest.Tests
{
    public class CircleTests
    {
        [TestCase(0.2, Math.PI * 0.2 * 0.2)]
        [TestCase(12, Math.PI * 12 * 12)]
        [TestCase(777, Math.PI * 777 * 777)]
        public void ValidCircleTest(double radius, double square)
        {
            Assert.That(new Circle(radius).Square, Is.EqualTo(square));
        }
        
        [TestCase(0)]
        [TestCase(-5)]
        public void InvalidCircleTest(double radius)
        {
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }
    }
}