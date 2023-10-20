using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance_management_system
{
    public partial class Home_Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tid"] != null)
            {
                string str_tid = Session["tid"].ToString();
                Int32 tid = Int32.Parse(str_tid);
                string dep = Session["department"].ToString();
                //Response.Write(dep);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
                List<string> subjects = new List<string>();
                List<int> sid = new List<int>();
                string query = "SELECT * FROM Teacher WHERE teacher_ID = (@teacher_id)";
                try
                {
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@teacher_id", tid);
                            cmd.Connection = con;
                            con.Open();
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    lblTid.Text = reader.GetInt32(0).ToString();
                                    lblName.Text = reader.GetString(1);
                                    lblEmail.Text = reader.GetString(2);
                                    lblMobile.Text = reader.GetString(3);
                                    lblDob.Text = reader.GetString(4);
                                    lbldepartment.Text = reader.GetString(5);
                                }
                            }
                            else
                            {
                                Response.Write("No Data");
                            }
                            con.Close();
                        }
                        string query2 = "SELECT subject_ID FROM Teaching WHERE teacher_ID = (@teacher_ID)";
                        using (SqlCommand cmd2 = new SqlCommand(query2))
                        {
                            cmd2.Parameters.AddWithValue("@teacher_ID", tid);
                            cmd2.Connection = con;
                            con.Open();
                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                while (reader2.Read())
                                {
                                    Int32 sub_id = reader2.GetInt32(0);
                                    sid.Add(sub_id);
                                }
                            }
                            reader2.Close();
                            foreach(int id in sid)
                            {
                                string query3 = "SELECT subject_name FROM Subject WHERE subject_ID = (@subject_ID)";
                                using (SqlCommand cmd3 = new SqlCommand(query3))
                                {
                                    cmd3.Parameters.AddWithValue("@subject_ID", id);
                                    cmd3.Connection = con;
                                    SqlDataReader reader3 = cmd3.ExecuteReader();
                                    if (reader3.HasRows)
                                    {
                                        while (reader3.Read())
                                        {
                                            string name = reader3.GetString(0);
                                            subjects.Add(name);
                                        }
                                    }
                                    reader3.Close();
                                }
                            }
                        }
                        foreach (string name in subjects)
                        {
                            lblsubject.Text += name + "<br/>";
                        }
                        //lblsubject.Text = subjects[0];
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                finally
                {
                    if (con != null && con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                Response.Redirect("Login_Teacher.aspx");
            }
        }
    }
}