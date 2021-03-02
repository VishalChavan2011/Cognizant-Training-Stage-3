using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Demo1
{
    public class Class1
    {
        class SyncClass
        {
            private int CountCharacters()
            {
                int count = 0;
                // Create a StreamReader and point it to the file to read
                using (StreamReader reader = new StreamReader(@"F:\\TextTest.txt"))
                {
                    string content = reader.ReadToEnd();
                    count = content.Length;
                    // Make the program look busy for 5 seconds
                    Thread.Sleep(5000);
                }
                return count;
            }
            public void ProcessFIle()
            {
                Console.WriteLine("Processing file. Please wait...");
                int count = CountCharacters();
                Console.WriteLine(count.ToString() + " characters in file");
            }
        }
    }
}
}
