using System;

namespace MindboxTest.AreaMeter.Shapes
{
    public abstract class Shape
    {
        /// <summary>
        /// Figure area
        /// </summary>
        public abstract double Square { get; }
        internal abstract void Validate();
        
        
    }
}