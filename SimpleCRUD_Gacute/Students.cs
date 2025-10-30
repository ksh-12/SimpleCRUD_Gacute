using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace SimpleCRUD_Gacute
{
    internal class Students
    {
        string connectionString = "server=localhost;database=studentsinformationsystem;uid=root;pwd=kishey;";

        //Add Students
        public void InsertStudent(string studentId, string fullName, string yearLevel, string course, string status)
        {
            using var conn = new MySqlConnection(connectionString);
            string q = "INSERT INTO students (Student_ID, FullName, Year_Level, Course, Status) " +
                       "VALUES (@Student_ID,@FullName,@Year_Level,@Course,@Status)";
            var cmd = new MySqlCommand(q, conn);
            cmd.Parameters.AddWithValue("@Student_ID", studentId);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Year_Level", yearLevel);
            cmd.Parameters.AddWithValue("@Course", course);
            cmd.Parameters.AddWithValue("@Status", status);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        //Update Students
        public void UpdateStudentAllFields(string originalId, string newId, string fullName, string yearLevel, string course, string status)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            //Check if the original record exists
            string checkQuery = "SELECT COUNT(*) FROM students WHERE Student_ID = @OriginalID";
            using (var checkCmd = new MySqlCommand(checkQuery, conn))
            {
                checkCmd.Parameters.AddWithValue("@OriginalID", originalId);
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (exists == 0)
                    throw new Exception("Student record not found.");
            }

            //If the user changed Student ID, ensure new one is unique
            if (!originalId.Equals(newId, StringComparison.OrdinalIgnoreCase))
            {
                string duplicateQuery = "SELECT COUNT(*) FROM students WHERE Student_ID = @NewID";
                using (var checkDup = new MySqlCommand(duplicateQuery, conn))
                {
                    checkDup.Parameters.AddWithValue("@NewID", newId);
                    int duplicate = Convert.ToInt32(checkDup.ExecuteScalar());
                    if (duplicate > 0)
                        throw new Exception("❌ The new Student ID already exists. Please use a different ID.");
                }
            }

            //Update Students
            string updateQuery = @"UPDATE students 
                           SET Student_ID = @NewID, FullName = @FullName, Year_Level = @YearLevel, 
                               Course = @Course, Status = @Status 
                           WHERE Student_ID = @OriginalID";

            using var cmd = new MySqlCommand(updateQuery, conn);
            cmd.Parameters.AddWithValue("@NewID", newId);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@YearLevel", yearLevel);
            cmd.Parameters.AddWithValue("@Course", course);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@OriginalID", originalId);

            cmd.ExecuteNonQuery();
        }

        //Delete Students
        public void DeleteStudent(string studentId)
        {
            using var conn = new MySqlConnection(connectionString);
            string q = "DELETE FROM students WHERE Student_ID=@Student_ID";
            var cmd = new MySqlCommand(q, conn);
            cmd.Parameters.AddWithValue("@Student_ID", studentId);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        //Get Students
        public DataTable GetAllStudents()
        {
            DataTable dt = new();
            using var conn = new MySqlConnection(connectionString);
            string q = "SELECT Student_ID,FullName,Year_Level,Course,Status FROM students";
            new MySqlDataAdapter(q, conn).Fill(dt);
            return dt;
        }

        //Search Students
        public DataTable SearchByStudentId(string studentId)
        {
            DataTable dt = new();
            using var conn = new MySqlConnection(connectionString);
            string query = "SELECT Student_ID, FullName, Year_Level, Course, Status FROM students WHERE Student_ID = @id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", studentId);
            new MySqlDataAdapter(cmd).Fill(dt);
            return dt;
        }
    }
}
