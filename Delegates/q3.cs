/* Create an interface IAnimal with a method Speak(). Implement the interface in two classesDog andCat, each providing their own implementation ofSpeak()*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animalQ3
{
    internal class Program
    {
        interface IAnimal
        {
            
            void Speak();
        }

        class Dog : IAnimal
        {
            
            public void Speak()
            {
                Console.WriteLine("Bow Bow....");
            }
        }

        class Cat : IAnimal
        {

            public void Speak()
            {
                Console.WriteLine("Meow Meow....");
            }
        }

        static void Main(string[] args)
        {
            IAnimal dog = new Dog();
            IAnimal cat = new Cat();

            
            dog.Speak();  
            cat.Speak();
        }
    }
}