using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Func<int, int, int> add = (a, b) => a + b;

            
            int result = add(5, 7);

            Console.WriteLine($"Sum : {result}");
        }
    }
}
