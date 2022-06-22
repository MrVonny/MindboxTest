using System;

namespace MindboxTest.AreaMeter.Shapes
{
    public abstract class Shape
    {
        public abstract double Square { get; }
        internal abstract void Validate();
        
        
    }
}