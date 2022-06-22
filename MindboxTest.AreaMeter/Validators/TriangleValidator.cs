using System.Collections.Generic;
using System.Linq;
using MindboxTest.AreaMeter.Shapes;

namespace MindboxTest.AreaMeter.Validators
{
    internal class TriangleValidator : ShapeValidator
    {
        private readonly Triangle _triangle;

        public TriangleValidator(Triangle triangle)
        {
            _triangle = triangle;
        }

        public override bool Validate()
        {
            var sides = new List<double>() { _triangle.A, _triangle.B, _triangle.C };
            if (sides.Any(side => side <= 0))
            {
                IsValid = false;
                Errors.Add("All sides of the triangle must be a positive value");
            }
            sides.Sort();
            if (sides[2] >= sides[0] + sides[1])
            {
                IsValid = false;
                Errors.Add("A triangle only exists if the sum of its two sides is greater than the third.");
            }
            
            return IsValid;
        }
    }
}