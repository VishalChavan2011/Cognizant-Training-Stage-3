using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{     
    public class Calculator:IDisposable
    {
        public int Addition(int x,int y)
        {
            return x + y;
        }

        public void Dispose()
        {
            //
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
