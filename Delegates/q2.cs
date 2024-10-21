/* Create an abstract classVehiclewith a propertySpeedand an abstract methodDrive(). Implement theDrive()method in two derived classes Car and
Bicycle */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicleQ2
{
    internal class Program
    {
        abstract class Vehicle
        {
            public int Speed { get; set; }

            public abstract void Drive();
        }

        class Car : Vehicle
        {
            
            public Car(int speedofcar)
            {
                Speed = speedofcar;
            }

            
            public override void Drive()
            {
                Console.WriteLine($"The speed of car is {Speed} km/h.");
            }
        }

        class Bicycle : Vehicle
        {
            
            public Bicycle(int speed)
            {
                Speed = speed;
            }

            public override void Drive()
            {
                Console.WriteLine($"The speed of bicycle is {Speed} km/h.");
            }
        }

        static void Main(string[] args)
        {
            Vehicle car = new Car(50);
            car.Drive();

            
            Vehicle bicycle = new Bicycle(15);
            bicycle.Drive();
        }
    }
}