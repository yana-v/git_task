using NUnit.Framework;
using xUnit;

namespace Tests
{
    public class TriangleTests
    {
        [Test]
        public void AllSidesAreEqual()
        {
            Assert.IsTrue(Triangle.IsTriangle(2, 2, 2));
        }
        [Test]
        public void AllSidesCannotBeZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 0, 0));
        }
        [Test]
        public void RightTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(3, 4, 5));
        }
        [Test]
        public void SideCannotBeZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 2, 2));
        }
        [Test]
        public void SideCannotBeLessThenZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(-2, 2, 2));
        }
        [Test]
        public void AllSidesCannotBeLessThenZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(-2, -2, -2));
        }
        [Test]
        public void SideNotLessThenSumOtherSides()
        {
            Assert.IsFalse(Triangle.IsTriangle(6, 8, 20));
        }
        [Test]
        public void NotIntValuesOfSides()
        {
            Assert.IsTrue(Triangle.IsTriangle(5.5, 6.6, 7.4));
        }
        [Test]
        public void IsoscelesTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(4, 4, 6));
        }
        [Test]
        public void NotCanBeIsoscelesTriangle()
        {
            Assert.IsFalse(Triangle.IsTriangle(4, 4, 9));
        }
    }
}