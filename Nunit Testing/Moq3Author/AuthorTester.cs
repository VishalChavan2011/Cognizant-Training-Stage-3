using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace Moq3Author
{
    [TestFixture]
    class AuthorTester
    {
         [Test]   
        public void TestAuthorMock()
        {
            var author = new Mock<IMocker>();
            author.SetupGet(p => p.Id).Returns(1);
            author.SetupGet(p => p.FirstName).Returns("Vishal");
            author.SetupGet(p => p.LastName).Returns("Chavan");
            Assert.AreEqual("Vshal", author.Object.FirstName);
        }

    }
}
