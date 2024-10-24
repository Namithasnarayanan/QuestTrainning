using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assessment_2.Program;

namespace Assessment_2
{
    public class DoctorManagement : ICrudOperations
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\HospitalManagement.mdf;Integrated Security=True;";

        public void Create()
        {
            Console.Write("Enter Doctor Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Specialization: ");
            string specialization = Console.ReadLine();
           Console.Write("Enter Patient ID to assign to doctor : ");
            string patientIdInput = Console.ReadLine();
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Doctor (Name, Specialization, PatientId) VALUES (@name, @specialization, @patientId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@specialization", specialization);
                cmd.Parameters.AddWithValue("@patientId", patientIdInput); 

                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Doctor added successfully.");
            }
        }

        public void Read()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Doctor";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Specialization: {reader["Specialization"]}, PatientId: {reader["PatientId"]}");
                }
            }
        }

        public void Update()
        {
            Console.Write("Enter Doctor ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter new Specialization: ");
            string specialization = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Doctor SET Specialization = @specialization WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@specialization", specialization);
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Doctor updated successfully.");
            }
        }

        public void Delete()
        {
            Console.Write("Enter Doctor ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Doctor WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Doctor deleted successfully.");
            }
        }
    }
}



