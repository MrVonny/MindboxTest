using System.Collections.Generic;

namespace MindboxTest.AreaMeter.Validators
{
    internal abstract class ShapeValidator
    {
        public bool IsValid { get; protected set; } = true;
        public List<string> Errors { get; } = new List<string>();

        public abstract bool Validate();
    }
}