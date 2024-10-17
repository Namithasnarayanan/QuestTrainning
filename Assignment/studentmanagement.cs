using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentinformation
{
    internal class student
    {
        public string Name;
        public int Regid;
        public int Class;
        public List<decimal> Marks = new List<decimal>();
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace studentinformation
{
    internal class studentmanage
    {
        List<student> listofstudents = new List<student>();

        public void Add(student student)
        {
            foreach (var item in listofstudents)
            {
                if (item.Regid == student.Regid)
                {
                    Console.WriteLine("Student already exists");
                    return;
                }
            }

            listofstudents.Add(student);
            Console.WriteLine(" Student Added successfully");
        }

        public void Search(int regid)
        {
            Console.WriteLine("Enter student id to search :");
            int idtosearch = int.Parse(Console.ReadLine());

            foreach (var item in listofstudents)
            {
                if (item.Regid == idtosearch)
                {
                    Console.WriteLine($"Student Found: Name = {item.Name}, RegID = {item.Regid}, Class = {item.Class}");
                    return;

                }
            }
        }

        public void Update(int regId)
        {
            foreach (var item in listofstudents)
            {
                if (item.Regid == regId)
                {
                    Console.WriteLine("Enter new details for the student:");

                    Console.Write("Enter the new name: ");
                    item.Name = Console.ReadLine();

                    Console.Write("Enter the new class number: ");
                    item.Class = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter marks: ");
                    var newMarks = Console.ReadLine().Split(',');
                    foreach (var mark in newMarks)
                    {
                        if (decimal.TryParse(mark.Trim(), out decimal parsedMark))
                            std.Mark.Add(parsedMark);
                    }


                    Console.WriteLine("Student updated successfully.");
                    return;
                }
            }
            Console.WriteLine("Student not found.");
        }


        public void Delete(int regId)
        {
            for (int i = 0; i < listofstudents.Count; i++)
            {
                if (listofstudents[i].Regid == regId)
                {
                    listofstudents.RemoveAt(i);
                    Console.WriteLine("Student deleted successfully.");
                    return;
                }
            }
            Console.WriteLine("Student not found.");
        }

        public void DisplayAllStudents()
        {
            if (listofstudents.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            Console.WriteLine("\nAll Students:");
            foreach (var student in listofstudents)
            {
                Console.WriteLine($"Name: {student.Name}, RegID: {student.Regid}, Class: {student.Class}, Mark: {student.Mark}");
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace studentinformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stdaccess = new studentmanage();



            Console.WriteLine("Enter your choice : 1.Add\n2.Search\n3.Update\n4.Delete\n5.Exit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var std = GetStudentdata();
                    stdaccess.Add(std);
                    break;
                case 2:
                    Console.Write("Enter the Registration ID to search: ");
                    int regId = int.Parse(Console.ReadLine());
                    stdaccess.Search(regId);
                    break;
                case 3:
                    Console.Write("Enter the Registration ID to update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    stdaccess.Update(updateId);
                    break;
                case 4:
                    Console.Write("Enter the Registration ID to delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    stdaccess.Update(deleteId);
                    break;
                case 5:
                    stdaccess.DisplayAllStudents();
                    break;
                case 6:
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;


            }
        }

        public static student GetStudentdata()
        {
            student std = new student();

            Console.Write("Enter the student name: ");
            std.Name = Console.ReadLine();

            Console.Write("Enter the Registration Id: ");
            std.Regid = int.Parse(Console.ReadLine());

            Console.Write("Enter the class ");
            std.Class = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter marks (comma-separated): ");
            var marksInput = Console.ReadLine().Split(',');
            foreach (var mark in marksInput)
            {
                if (decimal.TryParse(mark.Trim(), out decimal parsedMark))
                    std.Marks.Add(parsedMark);
            }


            return std;
        }
    }
}
