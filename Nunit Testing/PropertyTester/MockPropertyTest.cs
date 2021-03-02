using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;
using Mock2PropertyDemo;

namespace PropertyTester
{
    [TestFixture]
    public class MockPropertyTest
    {
        [Test]
        public void TestMocker()
        {
            //configuring mock object
            var mock = new Mock<IMocker>();
            //simulating the mocker property
            mock.SetupGet(x => x.PropertyToMock).Returns("FixedValue");
            var myTester = new ClassToTest();
            var actual = myTester.GetPrefixedValue(mock.Object);
            Assert.AreEqual("Prefixed:FixedValue", actual);
        }
    }
}