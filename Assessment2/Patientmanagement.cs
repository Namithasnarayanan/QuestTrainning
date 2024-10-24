using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static Assessment_2.Program;

namespace Assessment_2
{
    
        public class PatientManagement : ICrudOperations
        {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\HospitalManagement.mdf;Integrated Security = True;";

            public void Create()
            {
                Console.Write("Enter Patient Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Enter Gender : ");
                Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine(), true);
                Console.Write("Enter Medical Condition: ");
                string condition = Console.ReadLine();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Patient (Name, Age, Gender, MedicalCondition) VALUES (@name, @age, @gender, @condition)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@gender", gender.ToString());
                    cmd.Parameters.AddWithValue("@condition", condition);
                   

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Patient added successfully.");
                }
            }

            public void Read()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Patient";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}, Gender: {reader["Gender"]}, Condition: {reader["MedicalCondition"]}");
                    }
                }
            }

            public void Update()
            {
                Console.Write("Enter Patient ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter new Medical Condition: ");
                string condition = Console.ReadLine();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Patient SET MedicalCondition = @condition WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id",id);
                    cmd.Parameters.AddWithValue("@condition", condition);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Patient updated successfully.");
                }
            }

            public void Delete()
            {
                Console.Write("Enter Patient ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Patient WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Patient deleted successfully.");
                }
            }
        }


    }
