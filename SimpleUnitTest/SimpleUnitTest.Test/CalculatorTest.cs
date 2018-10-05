using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SimpleUnitTest.Test
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator _cal;

        [SetUp]
        public void Setup()
        {
            _cal = new Calculator();
        }
        [Test]
        public void OnePlusOneEqualTwo()//1 + 1 =2
        {
            Assert.AreEqual(2, _cal.Add(1, 1));
        }
        [Test]
        public void TwoPlusTwoEqualFour()//2+2=4
        {
            Assert.AreEqual(4, _cal.Add(2, 2));
        }
        [Test]
        public void FourPlusOneEqualFive()//4+1=5
        {
            Assert.AreEqual(5, _cal.Add(4, 1));
        }
    }
}
