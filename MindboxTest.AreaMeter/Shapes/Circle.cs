using System;
using MindboxTest.AreaMeter.Validators;

namespace MindboxTest.AreaMeter.Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            Radius = radius;
            Validate();
        }

        public override double Square => Math.PI * Radius * Radius;
        internal sealed override void Validate()
        {
            var validator = new CircleValidator(this);
            if (!validator.Validate())
            {
                throw new ArgumentException(string.Join("\n", validator.Errors));
            }
        }
    }
}