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
    public partial class Update_Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tid"] == null)
            {
                Response.Redirect("Login_Teacher.aspx");
            }
        }
        
        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            string str_tid = Session["tid"].ToString();
            Int32 tid = Int32.Parse(str_tid);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;



            try
            {
                using (con)
                {
                    if (txtUpdateEmail.Text != "")
                    {
                        string newemail = txtUpdateEmail.Text;
                        string query = "UPDATE Teacher SET email_ID = (@email) WHERE teacher_ID = (@teacher_id)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@email", newemail);
                            cmd.Parameters.AddWithValue("@teacher_id", tid);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    if (txtUpdateMobile.Text != "")
                    {
                        string newmobile = txtUpdateMobile.Text;
                        string query = "UPDATE Teacher SET mobile = (@mob) WHERE teacher_ID = (@teacher_id)";
                        using (con)
                        {
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Parameters.AddWithValue("@mob", newmobile);
                                cmd.Parameters.AddWithValue("@teacher_id", tid);
                                cmd.Connection = con;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Response.Redirect("Home_Teacher.aspx");
        }
    }
}