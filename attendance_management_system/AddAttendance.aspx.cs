using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance_management_system
{
    public partial class AddAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["studentID"] != null && Request.QueryString["subjectName"] != null)
            {
                string studentID = Request.QueryString["studentID"];
                string subjectName = Request.QueryString["subjectName"];
                stu_id.Value = studentID; ;
                sub_name.Value = subjectName;

                // Now you have the StudentID and SubjectID, you can use them as needed
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string student_id = stu_id.Value;
            string subjectName = sub_name.Value;
            int attendedLecture = Int32.Parse(txtAttendedLecture.Text);
            int totalLecture = Int32.Parse(txtTotalLecture.Text);
            int attendedLab = Int32.Parse(txtAttendedLab.Text);
            int totalLab = Int32.Parse(txtTotalLab.Text);
            string phase = ddlPhase.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
            string query = "SELECT subject_ID FROM Subject WHERE subject_name = (@sub)";
            int sub_id = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@sub", subjectName);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            sub_id = reader.GetInt32(0);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            if (phase == "Phase 1")
            {
                query = "UPDATE Attend SET phase1_lec_present = (@attendedLecture), phase1_lec_total = (@totalLecture), phase1_lab_present = (@attendedLab), phase1_lab_total = (@totalLab) WHERE student_ID = (@student_id) AND subject_ID = (@subject_id)";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@attendedLecture", attendedLecture);
                        cmd.Parameters.AddWithValue("@totalLecture", totalLecture);
                        cmd.Parameters.AddWithValue("@attendedLab", attendedLab);
                        cmd.Parameters.AddWithValue("@totalLab", totalLab);
                        cmd.Parameters.AddWithValue("@student_id", student_id);
                        cmd.Parameters.AddWithValue("@subject_id", sub_id);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Attendance Added Successfully');", true);
                    }
                }
                catch(Exception ex) {
                    Response.Write(ex);
                }
            }
            else if(phase == "Phase 2")
            {
                query = "UPDATE Attend SET phase2_lec_present = (@attendedLecture), phase2_lec_total = (@totalLecture), phase2_lab_present = (@attendedLab), phase2_lab_total = (@totalLab) WHERE student_ID = (@student_id) AND subject_ID = (@subject_id)";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@attendedLecture", attendedLecture);
                        cmd.Parameters.AddWithValue("@totalLecture", totalLecture);
                        cmd.Parameters.AddWithValue("@attendedLab", attendedLab);
                        cmd.Parameters.AddWithValue("@totalLab", totalLab);
                        cmd.Parameters.AddWithValue("@student_id", student_id);
                        cmd.Parameters.AddWithValue("@subject_id", sub_id);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Attendance Added Successfully');", true);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
            else if(phase == "Phase 3")
            {
                query = "UPDATE Attend SET phase3_lec_present = (@attendedLecture), phase3_lec_total = (@totalLecture), phase3_lab_present = (@attendedLab), phase3_lab_total = (@totalLab) WHERE student_ID = (@student_id) AND subject_ID = (@subject_id)";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@attendedLecture", attendedLecture);
                        cmd.Parameters.AddWithValue("@totalLecture", totalLecture);
                        cmd.Parameters.AddWithValue("@attendedLab", attendedLab);
                        cmd.Parameters.AddWithValue("@totalLab", totalLab);
                        cmd.Parameters.AddWithValue("@student_id", student_id);
                        cmd.Parameters.AddWithValue("@subject_id", sub_id);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Attendance Added Successfully');", true);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
    }
}