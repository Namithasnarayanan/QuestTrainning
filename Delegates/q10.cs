using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10
{
    internal class Program
    {
        static void DisplaySum(int a, int b) => Console.WriteLine($"The sum is: {a + b}");
       
        static void Main(string[] args)
        {
            Action<int, int> printSum = DisplaySum;

            
            printSum(55, 20);
            printSum(799, 95);
        }
    }
}
