using System;
using MindboxTest.AreaMeter.Shapes;
using NUnit.Framework;

namespace MindboxTest.Tests
{
    public class TriangleTests
    {
        [TestCase(3,4,5)]
        [TestCase(0.003,0.004,0.005)]
        [TestCase(3,4, 2.6457513110645907)]
        [TestCase(3, 0.3902439024390244, 2.8141544646247763)]
        [TestCase(10, 8, 14.011418433903117)]
        public void ValidTriangleFrom3SidesTest(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);
            Assert.Multiple(() =>
            {
                Assert.That(triangle.A, Is.EqualTo(a));
                Assert.That(triangle.B, Is.EqualTo(b));
                Assert.That(triangle.C, Is.EqualTo(c));
            });
        }

        [TestCase(3,4,11)]
        [TestCase(-2,2,-2)]
        [TestCase(0,0,0)]
        public void InvalidTriangleFrom3SidesTest(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(a,b,c));
        }
        
        [TestCase(3,4,Math.PI/2, 5)]
        [TestCase(34.78,12.78,0.2,22.399114934383949)]
        [TestCase(6,4,3,9.975953079120881)]
        public void ValidTriangleFrom2SidesTest(double a, double b, double angle, double expectedC)
        {
            var triangle = Triangle.FromTwoSidesAndAngle(a, b, angle);
            Assert.Multiple(() =>
            {
                Assert.That(triangle.A, Is.EqualTo(a));
                Assert.That(triangle.B, Is.EqualTo(b));
                Assert.That(triangle.C, Is.EqualTo(expectedC));
            });
        }

        [TestCase(1,2,Math.PI)]
        [TestCase(0,2,Math.PI/2)]
        [TestCase(-2,2,Math.PI/2)]
        public void InvalidTriangleFrom2SidesTest(double a, double b, double angle)
        {
            Assert.Throws<ArgumentException>(() => Triangle.FromTwoSidesAndAngle(a, b, angle));
        }
        
        [TestCase(10, 0.4, 0.6, 6.7101835189711299d,4.6278285209982926d )]
        [TestCase(5, 2, 1, 29.81402128502291d,32.217168894999354d )]
        [TestCase(1.543, Math.PI/2, 0.1, 0.15481639902785019d,1.5507472770919026d)]
        public void ValidTriangleFrom1SideTest(double side, double alpha, double beta, double expectedB, double expectedC)
        {
            var triangle = Triangle.FromTwoAngleAndSide(side, alpha, beta);
            Assert.Multiple(() =>
            {
                Assert.That(triangle.A, Is.EqualTo(side));
                Assert.That(triangle.B, Is.EqualTo(expectedB));
                Assert.That(triangle.C, Is.EqualTo(expectedC));
            });
        }

        [TestCase(1,Math.PI/2,Math.PI/2)]
        [TestCase(5,2,3)]
        [TestCase(-2,Math.PI/4,Math.PI/4)]
        [TestCase(0,Math.PI/4,Math.PI/4)]
        public void InvalidTriangleFrom1SideTest(double side, double alpha, double beta)
        {
            Assert.Throws<ArgumentException>(() => Triangle.FromTwoAngleAndSide(side, alpha, beta));
        }

        [TestCase(3,4, Math.PI/2)]
        [TestCase(1,54, Math.PI/2)]
        [TestCase(29,3, Math.PI/2)]
        [TestCase(2954,3, Math.PI/2)]
        [TestCase(0.034,0.1, Math.PI/2)]
        public void RightTriangleTest(double a, double b, double angle)
        {
            Assert.That(Triangle.FromTwoSidesAndAngle(a,b,angle).IsRight, Is.True);
        }
        
        [TestCase(3,4, Math.PI/2 - 0.1)]
        [TestCase(1,54, Math.PI/2 + 0.2)]
        [TestCase(0.4,0.00123, Math.PI/2 - 0.3)]
        public void RightTriangleNegativeTest(double a, double b, double angle)
        {
            Assert.That(Triangle.FromTwoSidesAndAngle(a,b,angle).IsRight, Is.False);
        }
        
    }
}