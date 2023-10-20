using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace attendance_management_system
{
    /// <summary>
    /// Summary description for StudentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class StudentService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public List<Student> GetStudentsBySemester(string subject_name)
        {
            List<Student> students = new List<Student>();
            string department = Session["department"].ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
            string query = "SELECT semester FROM Subject WHERE subject_name = (@sub_name)";
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@sub_name", subject_name);
                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        int sem = 0;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                sem = reader.GetInt32(0);
                            }
                        }
                        reader.Close();
                        Console.WriteLine("Semetser " + sem);
                        string query1 = "SELECT student_ID, name, semester FROM Student WHERE semester = (@sem) AND branch = (@branch)";
                        using(SqlCommand cmd1 = new SqlCommand(query1)) 
                        {
                            cmd1.Parameters.AddWithValue("@sem", sem);
                            cmd1.Parameters.AddWithValue("@branch", department);
                            cmd1.Connection = con;
                            reader = cmd1.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string id = reader.GetString(0);
                                    string name = reader.GetString(1);
                                    int smtr = reader.GetInt32(2);
                                    Student obj = new Student();
                                    obj.StudentID = id;
                                    obj.Name = name;
                                    obj.sem = smtr;
                                    students.Add(obj);
                                }
                            }
                            reader.Close();
                        }
                        con.Close();
                        Console.WriteLine("Hi");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return students;
        }

        public class Student
        {
            public string StudentID { get; set; }
            public string Name { get; set; }

            public int sem { get; set; }
        }
    }
}
