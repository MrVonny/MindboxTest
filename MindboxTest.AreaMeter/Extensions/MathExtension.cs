using System;

namespace MindboxTest.AreaMeter.Extensions
{
    public static class MathExtensions
    {
        public static bool NearlyEqual(this double a, double b, double epsilon)
        {
            const double minNormal = 2.2250738585072014E-308d;
            double absA = Math.Abs(a);
            double absB = Math.Abs(b);
            double diff = Math.Abs(a - b);

            if (a.Equals(b))
            {
                return true;
            }

            if (a == 0 || b == 0 || absA + absB < minNormal) 
            {
                return diff < (epsilon * minNormal);
            }
            
            return diff / (absA + absB) < epsilon;
        }
    }
}