using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q5
{
    internal class Program
    {
        delegate int Operation(int a, int b);

        class Calculator
        {

            public static int Add(int a, int b) => a + b;
            public static int Multiply(int a, int b) => a * b;

        }
        static void Main(string[] args)
        {
            Operation addition = new Operation(Calculator.Add);
            Operation multiplication = new Operation(Calculator.Multiply);

            
            int sum = addition(36, 5);
            Console.WriteLine($"Addition:{sum}");

            
            int product = multiplication(25, 5);
            Console.WriteLine($"Multiplication:  {product}");

        }
    }
}