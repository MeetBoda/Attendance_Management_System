using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace attendance_management_system
{
    public partial class Update_Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sid"] != null)
            {
                Debug.WriteLine("Hi");
                string student_id = Session["sid"].ToString();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
                try
                {
                    using (con)
                    {
                        int sem = 0;
                        Debug.WriteLine("Hi2");
                        string query = "SELECT semester FROM Student WHERE student_ID = (@stu_id)";
                        using(SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@stu_id", student_id);
                            cmd.Connection = con;
                            con.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if(reader.HasRows)
                            {
                                while(reader.Read())
                                {
                                    sem = reader.GetInt32(0);
                                    Debug.WriteLine("Hi3");
                                }
                            }
                            con.Close();
                        }
                        if(sem != 8)
                        {
                            sem++;
                            Debug.WriteLine(sem);
                            ListItem listItem = new ListItem("Semester " + sem.ToString(), sem.ToString());
                            ddlUpdateSemester.Items.Add(listItem);
                        }
                    }
                }
                catch(Exception ex) { 
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Response.Redirect("Login_Student.aspx");
            }
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            string student_id = Session["sid"].ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
            try
            {
                using (con)
                {
                    if (txtUpdateEmail.Text != "")
                    {
                        string newemail = txtUpdateEmail.Text;
                        string query = "UPDATE Student SET email_ID = (@email) WHERE student_ID = (@student_id)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@email", newemail);
                            cmd.Parameters.AddWithValue("@student_id", student_id);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    if (txtUpdateMobile.Text != "")
                    {
                        string newmobile = txtUpdateMobile.Text;
                        string query = "UPDATE Student SET mobile = (@mob) WHERE student_ID = (@student_id)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@mob", newmobile);
                            cmd.Parameters.AddWithValue("@student_id", student_id);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    if(ddlUpdateSemester.SelectedValue != "")
                    {
                        List<int> sub_ids = new List<int>();
                        int updatedsem = Int32.Parse(ddlUpdateSemester.SelectedValue);
                        string query = "UPDATE Student SET semester = (@sem) WHERE student_ID = (@student_id)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@sem", updatedsem);
                            cmd.Parameters.AddWithValue("@student_id", student_id);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        query = "SELECT subject_ID FROM Subject WHERE semester = (@sem)";
                        try
                        {
                            using (SqlCommand cmd1 = new SqlCommand(query))
                            {
                                cmd1.Parameters.AddWithValue("@sem", updatedsem);
                                cmd1.Connection = con;
                                con.Open();
                                SqlDataReader reader = cmd1.ExecuteReader();
                                Response.Write("Hello1");
                                while (reader.Read())
                                {
                                    int sub_id = reader.GetInt32(0);
                                    sub_ids.Add(sub_id);
                                }
                                reader.Close();
                                Response.Write("Hello3");
                                con.Close();
                                //Response.Redirect("Login_Student.aspx");
                            }
                        }
                        catch (Exception ex1)
                        {
                            Response.Write(ex1);
                        }
                        Response.Write(sub_ids.ToString());
                        string query2 = "INSERT INTO Attend (student_ID, subject_ID) VALUES (@student_id, @subject_id)";
                        try
                        {
                            foreach (int id in sub_ids)
                            {
                                using (SqlCommand cmd2 = new SqlCommand(query2))
                                {
                                    cmd2.Parameters.AddWithValue("@student_id", student_id);
                                    cmd2.Parameters.AddWithValue("@subject_id", id);
                                    cmd2.Connection = con;
                                    con.Open();
                                    cmd2.ExecuteNonQuery();
                                    con.Close();
                                    Response.Write("Hello2");
                                }
                            }
                        }
                        catch (Exception ex2)
                        {
                            Response.Write(ex2);
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Response.Redirect("HomePage.aspx");
        }
    }
}