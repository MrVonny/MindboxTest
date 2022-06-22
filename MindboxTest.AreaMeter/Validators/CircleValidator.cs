using MindboxTest.AreaMeter.Shapes;

namespace MindboxTest.AreaMeter.Validators
{
    internal class CircleValidator : ShapeValidator
    {
        private readonly Circle _circle;

        public CircleValidator(Circle circle)
        {
            _circle = circle;
        }

        public override bool Validate()
        {
            if (_circle.Radius <= 0)
            {
                IsValid = false;
                Errors.Add("Radius must be a positive value.");
            }

            return IsValid;
        }
    }
}