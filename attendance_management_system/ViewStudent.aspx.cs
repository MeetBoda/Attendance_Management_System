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
    public partial class ViewStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tid"] != null)
            {
                string str_tid = Session["tid"].ToString();
                Int32 tid = Int32.Parse(str_tid);
                string department = Session["department"].ToString();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
                List<string> subjects = new List<string>();
                List<int> sid = new List<int>();
                string query = "SELECT subject_ID FROM Teaching WHERE teacher_ID = (@teacher_ID)";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@teacher_ID", tid);
                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Int32 sub_id = reader.GetInt32(0);
                                sid.Add(sub_id);
                            }
                        }
                        else
                        {
                            Response.Write("Please Add Some Subjects First");
                        }
                        reader.Close();
                        foreach (int id in sid)
                        {
                            string query2 = "SELECT subject_name FROM Subject WHERE subject_ID = (@subject_ID) AND department = (@dep)";
                            using (SqlCommand cmd3 = new SqlCommand(query2))
                            {
                                cmd3.Parameters.AddWithValue("@subject_ID", id);
                                cmd3.Parameters.AddWithValue("@dep", department);
                                cmd3.Connection = con;
                                SqlDataReader reader2 = cmd3.ExecuteReader();
                                if (reader2.HasRows)
                                {
                                    while (reader2.Read())
                                    {
                                        string name = reader2.GetString(0);
                                        subjects.Add(name);
                                    }
                                }
                                reader2.Close();
                            }
                        }
                        foreach (string name in subjects)
                        {
                            ListItem item = new ListItem(name);
                            ddlSubject.Items.Add(item);
                        }
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