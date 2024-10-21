using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q6
{
    internal class Program
    {
        delegate void PrintMessage(string message);

        class MessagePrinter
        {
            
            public static void Displaymessage(string message)
            {
                Console.WriteLine($"Message: {message}");
            }
        }

        static void Main(string[] args)
        {
            PrintMessage print = new PrintMessage(MessagePrinter.Displaymessage);

            
            print("Hello!");

            
            print("How are you?");
        }
    }
}
