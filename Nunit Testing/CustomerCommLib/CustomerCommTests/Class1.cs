using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace CustomerCommTests
{[TestFixture]

    public class Class1
    {

        CustomeComm cust;
        [SetUp]
        public void SetAttribute()
        {
            bool check = false;
        }
        
        [TestCase("vishal","this is message",true)]
        [TestCase("vishal@cognizant.com", "Welcome Cognizant", true)]
        
        public void testfun(string toAddress,string message,bool check) 
        {
             var mock = new Mock<IMailSender>();
            
            cust = new CustomeComm(mock.Object);
            mock.Setup(p=>p.SendMail(toAddress ,message)).Returns(check);
            bool result = cust.SendMailToCustomer();
            Assert.AreEqual(check, result);
        }
    
    }
}
