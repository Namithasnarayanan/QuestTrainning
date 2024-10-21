using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculatorQ4
{
    internal class Program
    {
        interface ICalculator
        {
             int Add(int a, int b);

            int Subtract(int a, int b);
        }

        class SimpleCalculator : ICalculator
        {
            
            public int Add(int a, int b) => a + b;



            public int Subtract(int a, int b) => a - b;
           
        }
        static void Main(string[] args)
        {

            ICalculator calculator = new SimpleCalculator();

            
            int sum = calculator.Add(100, 5);
            Console.WriteLine($"Addition:  {sum}");

            
            int difference = calculator.Subtract(102, 5);
            Console.WriteLine($"Subtraction:  {difference}");
        }
    }
}
