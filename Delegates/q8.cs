using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string ,int> Lengthofstring = (s) => s.Length;

            Console.WriteLine($"Length of string': {Lengthofstring("Hello")}");
        }
    }
}
