using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Diagnostics;
using System.Web.UI;

namespace attendance_management_system
{
    /// <summary>
    /// Summary description for ViewStudentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ViewStudentService : System.Web.Services.WebService
    {
        public class Student
        {
            public string StudentID { get; set; }
            public string Name { get; set; }
            public int sem { get; set; }
            public double subject_attendance { get; set; }
            public double total_attendance { get; set; }
        }

        [WebMethod(EnableSession = true)]
        public List<Student> GetStudentsBySemester(string subject_name)
        {
            List<Student> students = new List<Student>();
            string department = Session["department"].ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
            int selected_subject_id = 0;
            int sem = 0;
            string query = "SELECT semester, subject_ID FROM Subject WHERE subject_name = (@sub_name)";
            Debug.WriteLine("Hi");
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
                        
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                sem = reader.GetInt32(0);
                                selected_subject_id = reader.GetInt32(1);
                                Debug.WriteLine("Selcted Subject : " + selected_subject_id);
                            }
                        }
                        reader.Close();
                    }    
                        //Console.WriteLine("Semetser " + sem);
                        string query1 = "SELECT student_ID, name, semester FROM Student WHERE semester = (@sem) AND branch = (@branch)";
                    using (SqlCommand cmd1 = new SqlCommand(query1))
                    {
                        cmd1.Parameters.AddWithValue("@sem", sem);
                        cmd1.Parameters.AddWithValue("@branch", department);
                        cmd1.Connection = con;
                        SqlDataReader reader = cmd1.ExecuteReader();
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
                                Debug.WriteLine(obj.StudentID + " " + obj.Name + " " + obj.sem);
                                students.Add(obj);
                            }
                        }
                        reader.Close();
                    }
                    for(int i = 0; i < students.Count; i++)
                    {
                        Student obj = students[i];
                        int present = 0;
                        int total = 0;
                        string query2 = "SELECT student_ID, subject_ID, phase1_lec_present, phase1_lec_total, phase1_lab_present, phase1_lab_total, phase2_lec_present, phase2_lec_total, phase2_lab_present, phase2_lab_total, phase3_lec_present, phase3_lec_total, phase3_lab_present, phase3_lab_total FROM Attend WHERE student_ID = (@student_id) AND subject_ID = (@sub_id)";
                        Debug.WriteLine(query2);
                        using (SqlCommand cmd2 = new SqlCommand(query2))
                        {
                            cmd2.Parameters.AddWithValue("@student_id", obj.StudentID);
                            cmd2.Parameters.AddWithValue("@sub_id", selected_subject_id);
                            Debug.WriteLine("Welcome1");
                            cmd2.Connection = con;
                            Debug.WriteLine("Welcome2");

                            Debug.WriteLine("Welcome3");
                            SqlDataReader reader = cmd2.ExecuteReader();
                            Debug.WriteLine(reader.ToString());
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    present += reader.GetInt32(2) + reader.GetInt32(4) + reader.GetInt32(6) + reader.GetInt32(8) + reader.GetInt32(10) + reader.GetInt32(12);
                                    total += reader.GetInt32(3) + reader.GetInt32(5) + reader.GetInt32(7) + reader.GetInt32(9) + reader.GetInt32(11) + reader.GetInt32(13);
                                }
                            }
                            reader.Close();
                        }
                        Debug.WriteLine("Present : " + present);
                        Debug.WriteLine("Total : " + total);
                        if(present != 0)
                        {
                            obj.subject_attendance = ((present * 1.0) / (total * 1.0)) * 100;
                            obj.subject_attendance = Math.Round(obj.subject_attendance, 2, MidpointRounding.ToEven);
                        }
                        else
                        {
                            obj.subject_attendance = 0; 
                        }
                        Debug.WriteLine(obj.subject_attendance);
                        present = 0;
                        total = 0;
                        query2 = "SELECT student_ID, subject_ID, phase1_lec_present, phase1_lec_total, phase1_lab_present, phase1_lab_total, phase2_lec_present, phase2_lec_total, phase2_lab_present, phase2_lab_total, phase3_lec_present, phase3_lec_total, phase3_lab_present, phase3_lab_total FROM Attend WHERE student_ID = (@student_id)";
                        using (SqlCommand cmd2 = new SqlCommand(query2))
                        {
                            cmd2.Parameters.AddWithValue("@student_id", obj.StudentID);
                            cmd2.Connection = con;
                            SqlDataReader reader = cmd2.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    present += reader.GetInt32(2) + reader.GetInt32(4) + reader.GetInt32(6) + reader.GetInt32(8) + reader.GetInt32(10) + reader.GetInt32(12);
                                    total += reader.GetInt32(3) + reader.GetInt32(5) + reader.GetInt32(7) + reader.GetInt32(9) + reader.GetInt32(11) + reader.GetInt32(13);
                                }
                            }
                            reader.Close();
                        }
                        Debug.WriteLine("Present : " + present);
                        Debug.WriteLine("Total : " + total);
                        if(present != 0)
                        {
                            obj.total_attendance = ((present * 1.0) / (total * 1.0)) * 100;
                            obj.total_attendance = Math.Round(obj.total_attendance, 2, MidpointRounding.ToEven);
                        }
                        else
                        {
                            obj.total_attendance = 0;
                        }
                        System.Diagnostics.Debug.WriteLine(obj.total_attendance);
                        //students.Add(obj);
                        Debug.WriteLine("Added");
                        students[i] = obj;
                    }
                    con.Close();
                    Debug.WriteLine("Finish");
                    //Console.WriteLine("Hi");    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return students;
        }
    }
}
