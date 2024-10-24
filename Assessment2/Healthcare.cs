using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static Assessment_2.Program;


namespace Assessment_2
{
    internal  class Program
    {
        public enum Gender 
        {   Male, 
            Female,
            Other 
        }

        public interface ICrudOperations
        {
            void Create();
            void Read();
            void Update();
            void Delete();
        }

        public abstract class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Person(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        public class Patient : Person
        {
            public int Age { get; set; }
            public Gender Gender { get; set; }
            public string MedicalCondition { get; set; }

            public Patient(int id, string name, int age, Gender gender, string condition)
                : base(id, name)
            {
                Age = age;
                Gender = gender;
                MedicalCondition = condition;
            }
        }

        public class Doctor : Person
        {
            public string Specialization { get; set; }
            public int PatientId { get; set; }

            public Doctor(int id, string name, string specialization, int patientId ) : base(id, name)
            {
                Specialization = specialization;
                PatientId = patientId;
            }
        }


        static void Main(string[] args)
        {

           
            PatientManagement patientManager = new PatientManagement();
            DoctorManagement doctorManager = new DoctorManagement();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n1. Add Patient");
                Console.WriteLine("2. View Patients");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. Delete Patient");
                Console.WriteLine("5. Add Doctor");
                Console.WriteLine("6. View Doctor");
                Console.WriteLine("7. Update Doctor");
                Console.WriteLine("8.Delete Doctor");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: 
                        patientManager.Create();
                        break;
                    case 2: 
                        patientManager.Read();
                        break;
                    case 3:
                        patientManager.Update(); 
                        break;
                    case 4:
                        patientManager.Delete();
                        break;
                    case 5:
                        doctorManager.Create(); 
                        break;
                    case 6: 
                        doctorManager.Read();
                        break;
                    case 7: doctorManager.Update();
                        break;
                    case 8: doctorManager.Delete();
                        break;

                    case 9:
                        exit = true; 
                        break;
                    default: 
                        Console.WriteLine("Invalid choice"); 
                        break;
                }
            }
        }
    }
}

