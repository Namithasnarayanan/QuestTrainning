using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q9
{
    internal class Program
    {
        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            Action<string> printMessage = DisplayMessage;

            
            printMessage("Welcome ");
        }
    }
}
