using System;

namespace xUnit
{
    public class Triangle
    {
        public static bool IsTriangle(double firstSide, double secondSide, double thirdSide)
        {
            return (firstSide + secondSide >= thirdSide && firstSide + thirdSide >= secondSide && secondSide + thirdSide >= firstSide && firstSide > 0 && secondSide > 0 && thirdSide > 0);
        }
    }
}
