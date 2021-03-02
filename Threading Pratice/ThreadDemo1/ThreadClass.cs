using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadDemo1
{
    class ThreadClass
    {
        public void CountEven()
        {
            for (int i = 0; i < 100; i += 2)
            {
                Console.WriteLine("T" + i);
                if (i == 50)
                {
                    Thread.Sleep(2000);
                }
            }
        }
        public void CountOdd()
        {
            for (int i = 1; i < 100; i += 2)
            {
                Console.WriteLine("T" + i);
            }
        }
    }
}
