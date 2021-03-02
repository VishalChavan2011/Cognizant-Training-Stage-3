using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Main Thread");
            Thread.CurrentThread.Name="Main";
            Console.WriteLine("Name " + Thread.CurrentThread.Name);

            ThreadClass td = new ThreadClass();
            Thread thread1 = new Thread(td.CountEven);
            Thread thread2 = new Thread(td.CountOdd);

            thread1.Start();
            thread2.Start();
            Thread.Sleep(500);

            Console.WriteLine(Thread.CurrentThread.Name +" Ends");
            

            Console.ReadLine();

        }
    }
}
