using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using StudentsFormApp.Dto;

namespace StudentsFormApp.Services
{
    public interface IStudentService
    {
        bool InsertStudent(Students students);
        List<Students> getAllStudents();
        Students getStudentById(int studentId);

        bool updateStudent(Students student);
        bool deleteStudent(int studentId);

    }

    public class studentServices : IStudentService
    {
        private readonly string connectionString;
        public studentServices()
        {
            connectionString = "Server=DESKTOP-0A43HJ8\\MSSQLSERVER01;Database=StudentForm;Integrated Security=True;TrustServerCertificate=True;";
        }
        public Students getStudentById(int studentId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "select * from students where Id=@id";
                using(var command = new SqlCommand(query,connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("id",studentId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Students { Id = Convert.ToInt32(reader["Id"]), Address = reader["Address"].ToString(), Age = Convert.ToInt32(reader["Age"]), Course = reader["Course"].ToString(), FatherName = reader["FatherName"].ToString(), Gender = reader["Gender"].ToString(), Name = reader["Name"].ToString() };
                    }
                return null;

                }
            }
        }
        public List<Students> getAllStudents()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var students = new List<Students>();
                var query = "select * from students";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var stud = new Students {Id= Convert.ToInt32(reader["Id"]), Address = reader["Address"].ToString(), Age = Convert.ToInt32(reader["Age"]), Course = reader["Course"].ToString(), FatherName = reader["FatherName"].ToString(), Gender = reader["Gender"].ToString(), Name = reader["Name"].ToString() };
                        students.Add(stud);

                    }
                    return students;

                }
            }
        }
        public bool deleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var query = "delete from students where Id=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("id", id);
                    int rowAffetced=command.ExecuteNonQuery();
                    return rowAffetced > 0;
                }

            }
        }
        public bool InsertStudent(Students students)
        {
            string query = "insert into Students(Name, Age, Address, FatherName, Course, Gender) values (@name, @age, @address, @fatherName, @course, @gender)";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", students.Name);
                    command.Parameters.AddWithValue("@age", students.Age);
                    command.Parameters.AddWithValue("@address", students.Address);
                    command.Parameters.AddWithValue("@fatherName", students.FatherName);
                    command.Parameters.AddWithValue("@course", students.Course);
                    command.Parameters.AddWithValue("@gender", students.Gender);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool updateStudent(Students students)
        {
            string query = "update  Students set Name=@name, Age=@age, Address= @address, FatherName= @fatherName, Course=@course, Gender=@gender where Id=@id";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", students.Id);
                    command.Parameters.AddWithValue("@name", students.Name);
                    command.Parameters.AddWithValue("@age", students.Age);
                    command.Parameters.AddWithValue("@address", students.Address);
                    command.Parameters.AddWithValue("@fatherName", students.FatherName);
                    command.Parameters.AddWithValue("@course", students.Course);
                    command.Parameters.AddWithValue("@gender", students.Gender);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

    }
}
