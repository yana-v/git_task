using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnit
{

    public class Triangle
    {
        public static bool IsTriangle(double a, double b, double c)
        {
            if (a + b >= c && a + c >= b && b + c >= a && a > 0 && b > 0 && c > 0)
                return true;
            else
                return false;

        }

        
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
