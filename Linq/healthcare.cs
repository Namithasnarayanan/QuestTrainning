using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare
{
    internal class Program
    {
        public class Patient
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public string MedicalCondition { get; set; }
        }

        public class Appointment
        {
            public int Id { get; set; }
            public int PatientId { get; set; }
            public string DoctorName { get; set; }
            public DateTime AppointmentDate { get; set; }
            public string AppointmentType { get; set; }
        }
        static void Main(string[] args)
        {

            var patients = new List<Patient>
            {
               new Patient { Id = 1, Name = "Namitha", Age = 22, Gender = "Female", MedicalCondition = "Hypertension" },
               new Patient { Id = 2, Name = "Anusree", Age = 23, Gender = "Male", MedicalCondition = "Diabetes" },
               new Patient { Id = 3, Name = "Keerthana", Age = 30, Gender = "Male", MedicalCondition = "Heart Disease" }
            };

            var appointments = new List<Appointment>
            {
              new Appointment { Id = 1, PatientId = 1, DoctorName = "Dr. Nayana", AppointmentDate = DateTime.Now.AddDays(3), AppointmentType = "Consultation" },
              new Appointment { Id = 2, PatientId = 2, DoctorName = "Dr. Padmavathy", AppointmentDate = DateTime.Now.AddDays(-10), AppointmentType = "Follow-up" },
              new Appointment { Id = 3, PatientId = 1, DoctorName = "Dr. Venugopal", AppointmentDate = DateTime.Now.AddDays(-5), AppointmentType = "Consultation" },
              new Appointment { Id = 4, PatientId = 3, DoctorName = "Dr. Janardhanan", AppointmentDate = DateTime.Now.AddDays(2), AppointmentType = "Surgery" }
            };



            var upcomingPatients = patients.Where(p => appointments.Any(a => a.PatientId == p.Id && a.AppointmentDate >= DateTime.Now &&a.AppointmentDate <= DateTime.Now.AddDays(7))) 
                .Select(p => new
                 {
                      p.Name,
                      p.Age,
                      p.MedicalCondition
                 });

            foreach (var patient in upcomingPatients)
            {
                Console.WriteLine($"Name: {patient.Name}, Age: {patient.Age}, Condition: {patient.MedicalCondition}");
            }

         var groupedPatients = patients.Where(p => appointments.Any(a => a.PatientId == p.Id && a.AppointmentDate >= DateTime.Now && a.AppointmentDate <= DateTime.Now.AddDays(7)))
                         .GroupBy(p => p.MedicalCondition)
                         .Select(g => new
                          {
                              MedicalCondition = g.Key,
                               PatientCount = g.Count()
                          });

            foreach (var group in groupedPatients)
            {
                Console.WriteLine($"Condition: {group.MedicalCondition}, Count: {group.PatientCount}");
            }



        }
    }
}