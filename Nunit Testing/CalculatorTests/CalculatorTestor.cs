using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CalcLibrary;


namespace CalculatorTests
{  [TestFixture]
    public class CalculatorTestor
    {
        Calculator calc;
        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }
       [Test]
       public void Test_Addition()
        {
            
            var result = calc.Addition(3, 5);
            Assert.AreEqual(8, result);
        }
         [TestCase(1,2,3)]
         [TestCase(2,3,5)]
        public void TesCase_Addition(int first,int second, int result)
        {
          
            var expectedresult = calc.Addition(first, second);
            Assert.AreEqual(expectedresult, result);

        }

        [TearDown]
        public void TearDown()
        {
            calc.Dispose();
        }


        
    }
}
