using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock2PropertyDemo
{
   
        public class ClassToTest
        {
            //method to be tested
            public string GetPrefixedValue(IMocker provider)
            {
                return "Prefixed:" + provider.PropertyToMock;
            }
        
        }
}
