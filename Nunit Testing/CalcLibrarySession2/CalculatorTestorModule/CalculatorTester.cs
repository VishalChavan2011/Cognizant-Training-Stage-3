using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcLibrary;

namespace CalculatorTestorModule
{[TestFixture]
    public class CalculatorTester
    {
        SimpleCalculator sc;

        [SetUp]
        public void Setup()
        {
            sc = new SimpleCalculator();
        }


        [TestCase(9,7,2)]
        [TestCase(10,2,8)]
        public void SubstractionTest(double a, double b, double expectedresult)
        {
            double result = sc.Subtraction(a, b);
            Assert.AreEqual(expectedresult, result);
            
        }

        [TestCase(10,10,100)]
        public void MultiplicationTest(double a, double b,double expectedresult)
        {
            double result = sc.Multiplication(a, b);
            Assert.AreEqual(expectedresult, result);
        }

        [TestCase(1,0,0)]

        [TestCase(4, 2, 2)]
        public void DivisionTestException(double a, double b, double expectedresult)
        {
            try
            {
                Assert.AreEqual(expectedresult, sc.Division(a, b));
            }
            catch(Exception)
            {
                Assert.Fail("Division By Zero");
            }
            
        }



       

    }
}
