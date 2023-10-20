using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance_management_system
{
    public partial class Signup_Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignupButton_Click(object sender, EventArgs e)
        {
            // Handle signup logic here
            string name = nameTextBox.Text;
            string student_id = idNoTextBox.Text;
            string dob = dobTextBox.Text;
            string mobile = mobileTextBox.Text;
            int semester = int.Parse(semesterDropDown.Text);
            string email = emailTextBox.Text;
            string branch = DropDownList2.Text;
            List<int> sub_ids = new List<int>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
            string query = "INSERT INTO Student (student_ID, name, email_ID, mobile, semester, dob, branch) VALUES(@student_ID, @name, @email_ID, @mobile, @semester, @dob, @branch)";
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@student_ID", student_id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email_ID", email);
                        cmd.Parameters.AddWithValue("@dob", dob);
                        cmd.Parameters.AddWithValue("@semester", semester);
                        cmd.Parameters.AddWithValue("@mobile", mobile);
                        cmd.Parameters.AddWithValue("@branch", branch);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        query = "SELECT subject_ID FROM Subject WHERE semester = (@sem)";
                        try
                        {
                            using (SqlCommand cmd1 = new SqlCommand(query))
                            {
                                cmd1.Parameters.AddWithValue("@sem", semester);
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
                Response.Redirect("Login_Student.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            
            
            //query = "SELECT subject_ID FROM Subject WHERE semester = (@sem)";
            //try
            //{
            //    using (SqlCommand cmd = new SqlCommand(query))
            //    {
            //        cmd.Parameters.AddWithValue("@sem", semester);
            //        cmd.Connection = con;
            //        //con.Open();
            //        SqlDataReader reader = cmd.ExecuteReader();
            //        if (reader.Read())
            //        {
            //            while (reader.Read())
            //            {
            //                int sub_id = reader.GetInt32(0);
            //                string query2 = "INSERT INTO Attend (student_ID, subject_ID) VALUES (@student_id, @subject_id)";
            //                try
            //                {
            //                    using (SqlCommand cmd2 = new SqlCommand(query2))
            //                    {
            //                        cmd2.Parameters.AddWithValue("@student_id", student_id);
            //                        cmd2.Parameters.AddWithValue("@subject_id", sub_id);
            //                        cmd2.Connection = con;
            //                        con.Open();
            //                        cmd2.ExecuteNonQuery();
            //                        con.Close();
            //                    }
            //                }
            //                catch (Exception ex2)
            //                {
            //                    Response.Write(ex2);
            //                }
            //            }
            //        }
            //        //con.Close();
            //        Response.Redirect("Login_Student.aspx");
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Response.Write(ex);
            //}
            // Store the user information in your database or perform other necessary actions
            // Redirect the user to the appropriate page after successful signup
        }
    }
}