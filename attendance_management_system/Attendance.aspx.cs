using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace attendance_management_system
{
    public partial class Attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["sid"] != null)
            {
                int sem = 0;
                if (Request.QueryString["semester"] != null)
                {
                    sem = Int32.Parse(Request.QueryString["semester"]);
                    Debug.WriteLine(sem);
                }
                List<string> sub_names = new List<string>();
                List<int> sub_ids = new List<int>();
                List<AttendanceData> attendance_data = new List<AttendanceData>();
                string student_id = Session["sid"].ToString();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
                try
                {
                    using (con)
                    {
                        string query = "SELECT subject_ID, subject_name FROM Subject WHERE semester = (@sem) ORDER BY subject_ID ASC";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@sem", sem);
                            cmd.Connection = con;
                            con.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int subject_id = reader.GetInt32(0);
                                    string name = reader.GetString(1);
                                    sub_ids.Add(subject_id);
                                    sub_names.Add(name);
                                    Debug.WriteLine(name);
                                }
                            }
                            con.Close();
                        }
                        int lab_present = 0;
                        int lab_total = 0;
                        int lecture_present = 0;
                        int lecture_total = 0;
                        query = "SELECT * FROM Attend WHERE student_ID = (@student_id) ORDER BY subject_ID ASC";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            int index = 0;
                            cmd.Parameters.AddWithValue("@student_id", student_id);
                            cmd.Connection = con;
                            con.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if(reader.HasRows)
                            {
                                while(reader.Read() && index < sub_ids.Count)
                                {
                                    if(reader.GetInt32(1) == sub_ids[index])
                                    {
                                        AttendanceData attendance = new AttendanceData();
                                        attendance.SubjectName = sub_names[index];
                                        //Phase1
                                        attendance.Phase1LecturePresent = reader.GetInt32(2);
                                        lecture_present += attendance.Phase1LecturePresent;
                                        attendance.Phase1LectureTotal = reader.GetInt32(3);
                                        lecture_total += attendance.Phase1LectureTotal;
                                        attendance.Phase1LabPresent = reader.GetInt32(4);
                                        lab_present += attendance.Phase1LabPresent;
                                        attendance.Phase1LabTotal = reader.GetInt32(5);
                                        lab_total += attendance.Phase1LabTotal;
                                        //Phase2
                                        attendance.Phase2LecturePresent = reader.GetInt32(6);
                                        lecture_present += attendance.Phase2LecturePresent;
                                        attendance.Phase2LectureTotal = reader.GetInt32(7);
                                        lecture_total += attendance.Phase2LectureTotal;
                                        attendance.Phase2LabPresent = reader.GetInt32(8);
                                        lab_present += attendance.Phase2LabPresent;
                                        attendance.Phase2LabTotal = reader.GetInt32(9);
                                        lab_total += attendance.Phase2LabTotal;
                                        //Phase2
                                        attendance.Phase3LecturePresent = reader.GetInt32(10);
                                        lecture_present += attendance.Phase3LecturePresent;
                                        attendance.Phase3LectureTotal = reader.GetInt32(11);
                                        lecture_total += attendance.Phase3LectureTotal;
                                        attendance.Phase3LabPresent = reader.GetInt32(12);
                                        lab_present += attendance.Phase3LabPresent;
                                        attendance.Phase3LabTotal = reader.GetInt32(13);
                                        lab_total += attendance.Phase3LabTotal;
                                        // Add in the List
                                        attendance_data.Add(attendance);
                                        index++;
                                        Debug.WriteLine(index);
                                        Debug.WriteLine(lecture_present + lab_present);
                                        Debug.WriteLine(lecture_total + lab_total);
                                    }
                                }
                            }
                            con.Close();
                            rptSubjects.DataSource = attendance_data;
                            rptSubjects.DataBind();
                            lec_attend.Text = "Lecture Attendance : " + lecture_present + "/" + lecture_total;
                            lab_attend.Text = "Lab Attendance : " + lab_present + "/" + lab_total;
                            int sum = lecture_total + lab_total;
                            if (sum != 0) {
                                double total_attendance = ((((lecture_present + lab_present) * 1.0) / (lecture_total + lab_total)) * 100);
                                total_attendance = Math.Round(total_attendance, 2);
                                total_attend.Text = "Total Attendance : " + total_attendance + "%";
                            }
                            else
                            {
                                total_attend.Text = "Total Attendance : 0%";
                            }
                            Debug.WriteLine("Finish");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Response.Redirect("Login_Student.aspx");
            }
        }

        public class AttendanceData
        {
            public string SubjectName { get; set; }
            public int Phase1LecturePresent { get; set; }
            public int Phase1LectureTotal { get; set; }
            public int Phase1LabPresent { get; set; }
            public int Phase1LabTotal { get; set; }
            public int Phase2LecturePresent { get; set; }
            public int Phase2LectureTotal { get; set; }
            public int Phase2LabPresent { get; set; }
            public int Phase2LabTotal { get; set; }
            public int Phase3LecturePresent { get; set; }
            public int Phase3LectureTotal { get; set; }
            public int Phase3LabPresent { get; set; }
            public int Phase3LabTotal { get; set; }
        }
    }
}