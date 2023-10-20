using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance_management_system
{
    public partial class AddSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tid"] == null)
            {
                Response.Redirect("Login_Teacher.aspx");
            }
        }

        protected void btnAddSubject_Click(object sender, EventArgs e)
        {
            //string subject = ddlSubject.Text;
            string subject = sub_name.Value;
            Console.WriteLine(subject);
            Response.Write("Subject " + subject);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
            string query1 = "SELECT subject_ID  FROM Subject WHERE subject_name = (@sub_name)";
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand(query1))
                    {
                        Response.Write(subject);
                        cmd.Parameters.AddWithValue("@sub_name", subject);
                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        Int32 subject_id = 20;
                        while (reader.Read())
                        {
                            subject_id = reader.GetInt32(0);
                        }
                        
                        string query2 = "INSERT INTO Teaching (teacher_ID, subject_ID) VALUES(@teacher_id, @subject_id)";
                        string str_tid = Session["tid"].ToString();
                        Int32 tid = Int32.Parse(str_tid);
                        Response.Write("Subject ID : " + subject_id);
                        Response.Write("Teacher ID : " +  tid);
                        con.Close();
                        using (SqlCommand cmd2 = new SqlCommand(query2))
                        {
                            cmd2.Parameters.AddWithValue("@subject_id", subject_id);
                            cmd2.Parameters.AddWithValue("@teacher_id", tid);
                            cmd2.Connection = con;
                            con.Open();
                            cmd2.ExecuteNonQuery();
                            con.Close();
                        }
                        Response.Redirect("Home_Teacher.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}