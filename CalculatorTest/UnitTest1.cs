using System;
using Domain;

namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var calculator = new Calculator();
            var result = calculator.Sum(2, 2);

            Assert.AreEqual(4, result);
        }
    }
}