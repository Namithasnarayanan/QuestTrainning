using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitalmanagement
{
    internal class Program
    {
       static List<string> departments = new List<string>();
       static Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>(); 
       static Dictionary<string, string> patients = new Dictionary<string, string>(); 


        public static void AddDepartment()
        {
            Console.WriteLine("Enter department name: ");
            string deptname = Console.ReadLine();
            doctors[deptname] = new List<string>();
            if (departments.Contains(deptname)!= true)
            {
                departments.Add(deptname);
                doctors[deptname] = new List<string>();

            }
            else
            {
                Console.WriteLine("Department already exist");
            }
        }

        static void AddDoctor()
        {
            Console.Write("Enter doctor name: ");
            string doctorName = Console.ReadLine();
            Console.Write("Enter department for doctor: ");
            string department = Console.ReadLine();

            if (departments.Contains(department))
            {
                doctors[department].Add(doctorName);
                
            }
            else
            {
                Console.WriteLine("Department does not exist");
            }
            
        }
        static void AdmitPatient()
        {
            Console.Write("Enter patient name: ");
            string Nameofpatient = Console.ReadLine();
            Console.Write("Enter doctor name for the patient: ");
            string assignedDoctor = Console.ReadLine();

            
            bool Doctorforpatient = false;
            foreach (var x in doctors)
            {
                if (x.Value.Contains(assignedDoctor))
                {
                    Doctorforpatient = true;
                    break;
                }
            }

            if (Doctorforpatient)
            {
                patients[Nameofpatient] = assignedDoctor; 
                Console.WriteLine("Patient is admitted");
            }
            else
            {
                Console.WriteLine("Doctor does not exist");
            }
        }

        static void ListDoctorsInDepartment()
        {
            Console.Write("Enter department name: ");
            string searchDepartment = Console.ReadLine();
            if (doctors.ContainsKey(searchDepartment))
            {
                Console.WriteLine($"Doctors in {searchDepartment}:");
                foreach (var doctor in doctors[searchDepartment])
                {
                    Console.WriteLine(doctor);
                }
            }
            else
            {
                Console.WriteLine("No doctors found in this department.");
            }
        }

        static void ListPatientOfDoctor()
        {
            Console.Write("Enter  name of the doctor: ");
            string doctorNameToSearch = Console.ReadLine();
            Console.WriteLine($"Patients assigned to Dr. { doctorNameToSearch }:");
            bool patientfound = false;

            foreach (var x in patients)
            {
                if (x.Value.Equals(doctorNameToSearch, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(x.Key); 
                    patientfound = true;
                }
            }

            if (patientfound!=true)
            {
                Console.WriteLine("No patients assigned to this doctor.");
            }
        }
        static void DischargePatient()
        {
            Console.Write("Enter name of the patient to  be discharged: ");
            string patientToDischarge = Console.ReadLine();
            if (patients.ContainsKey(patientToDischarge))
            {
                patients.Remove(patientToDischarge);
                Console.WriteLine("Patient discharged.");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }


        static void Main(string[] args)
        {
            while(true)
            {
            Console.WriteLine("Enter your choice : \n1.Add Department\n2.Add Doctor\n3.Admit Patient \n4.List Doctors in Department\n5.List Patients of a doctor\n6.Discharge Patient\n7.Exit");
            int choice =int.Parse( Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddDepartment();
                    break;
                case 2:
                    AddDoctor();
                    break;
                case 3:
                    AdmitPatient();
                    break;
                case 4:
                    ListDoctorsInDepartment();
                    break;
                case 5:
                    ListPatientOfDoctor();
                    break;
                case 6:
                    DischargePatient();
                    break;
                case 7:
                    Console.WriteLine("Exiting");
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;

            }

        }
    }
}
}