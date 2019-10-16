using NUnit.Framework;
using xUnit;

namespace Tests
{
    public class TriangleTests
    {
        private static readonly int[][] CorrectSidesForTriangle =
        {
                new int[] { 2, 2, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 4, 4, 6 }
        };

        private static readonly int[][] WrongSidesForTriangle =
        {
                new int[] { 0, 0, 0 },
                new int[] { 2, 0, 2 },
                new int[] { -2, 2, 2 },
                new int[] { -2, -2, -2 },
                new int[] { 6, 8, 20 },
                new int[] { 4, 4, 9 }
        };

        [TestCaseSource("WrongSidesForTriangle")]
        public void NotValidSides(int a, int b, int c)
        {
            Assert.IsFalse(Triangle.IsTriangle(a, b, c));
        }
        
        [TestCaseSource("CorrectSidesForTriangle")]
        public void ValidSides(int a, int b, int c)
        {
            Assert.IsTrue(Triangle.IsTriangle(a, b, c));
        }

        [Test]
        public void NotCanBeIsoscelesTriangle()
        {
            Assert.IsFalse(Triangle.IsTriangle(4, 4, 9));
        }
        
    }
}