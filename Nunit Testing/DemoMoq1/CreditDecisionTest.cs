using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace DemoMoq1
{[TestFixture]
    class CreditDecisionTest
    {
        
        Mock<ICreditDecisionService> mock;
        CreditDecision systemUnderTest;
        
        [TestCase(100, "Declined")]
        [TestCase(549, "Declined")]
        [TestCase(550, "Maybe")]
        [TestCase(674, "Maybe")]
        [TestCase(675, "We look forward to doing business with you!")]

        [Test]
        public void MakeCreditDecision_Always_ReturnsExpectedResult(int creditScore, string expectedResult)
        {
            mock = new Mock<ICreditDecisionService>(MockBehavior.Strict);
            systemUnderTest = new CreditDecision(mock.Object);
            mock.Setup(p => p.GetCreditDecision(creditScore)).Returns(expectedResult);
            string actual = systemUnderTest.MakeCreditDecision(creditScore);
            Assert.AreEqual(actual, expectedResult);
        }

    }
}
