using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2_Nunit
{   
    public class Calculator
    {
        public int Substraction( int a, int b)
        {
            if(a<b)
            {
                throw new ArgumentException(String.Format("First Number {0} Smaller then Second {1}", a, b));
            }

            return a - b;
        }

       
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
