using System;
using System.Linq;
using MindboxTest.AreaMeter.Extensions;
using MindboxTest.AreaMeter.Validators;

namespace MindboxTest.AreaMeter.Shapes
{
    public class Triangle : Shape
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        
        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
            
            Validate();
        }

        public override double Square
        {
            get
            {
                var p = (A + B + C) / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }

        /// <summary>
        /// Is triangle right (Has a 90 degree angle).
        /// </summary>
        public bool IsRight => (A * A + B * B).NearlyEqual(C * C, new []{A,B,C}.Max() / 10e6) ||
                               (A * A + C * C).NearlyEqual(B * B, new []{A,B,C}.Max() / 10e6) ||
                               (C * C + B * B).NearlyEqual(A * A, new []{A,B,C}.Max() / 10e6);

        internal sealed override void Validate()
        {
            var validator = new TriangleValidator(this);
            if (!validator.Validate())
            {
                throw new ArgumentException(string.Join("\n", validator.Errors));
            }
        }
        
        /// <summary>
        /// Creates a triangle using two sides and an angle between them.
        /// </summary>
        /// <param name="a">First side length</param>
        /// <param name="b">Second side length</param>
        /// <param name="angle">Angle in radians</param>
        /// <returns></returns>
        public static Triangle FromTwoSidesAndAngle(double a, double b, double angle)
        {
            var c = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(angle));
            return new Triangle(a, b, c);
        }
        
        /// <summary>
        /// Creates a triangle using two angles and an side between them.
        /// </summary>
        /// <param name="side">Side length</param>
        /// <param name="alpha">First angle in radians</param>
        /// <param name="beta">Second angle in radians</param>
        /// <returns></returns>
        public static Triangle FromTwoAnglesAndSide(double side, double alpha, double beta)
        {
            var theta = Math.PI - alpha - beta;
            var b = side / Math.Sin(theta) * Math.Sin(beta);
            var c = side / Math.Sin(theta) * Math.Sin(alpha);
            return new Triangle(side, b, c);
        }
    }
}