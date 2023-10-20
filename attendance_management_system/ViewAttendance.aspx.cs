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
    public partial class ViewAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sid"] != null)
            {
                string sid = Session["sid"].ToString();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
                try
                {
                    using (con)
                    {
                        int sem = 0;
                        List<int> semesters = new List<int>();
                        string query = "SELECT semester FROM Student WHERE student_ID = (@sid)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@sid", sid);
                            cmd.Connection = con;
                            con.Open();
                            SqlDataReader reader = cmd.ExecuteReader();
                            if(reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    sem = reader.GetInt32(0);
                                }
                            }
                            con.Close();
                        }
                        for(int i = 1; i <= sem; i++)
                        {
                            semesters.Add(i);
                            //var row = "<tr><td>" + i + "</td><td>" + "<a href='Attendance.aspx?semester='" + i + "'>View</a></td></tr>";
                            //tablebody.append(row);
                        }
                        rptSemesters.DataSource = semesters;
                        rptSemesters.DataBind();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                Response.Redirect("Login_Student.aspx");
            }
        }
    }
}