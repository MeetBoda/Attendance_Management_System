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
    public partial class Login_Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;

            int teacher_ID = int.Parse(loginIdTextBox.Text);
            string dob = loginDobTextBox.Text;


            string query = "SELECT teacher_ID, dob, department FROM Teacher WHERE teacher_ID = (@teacher_id)";
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@teacher_id", teacher_ID);
                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int tid = reader.GetInt32(0);
                                string dateob = reader.GetString(1);
                                string department = reader.GetString(2);

                                if (dateob == dob)
                                {
                                    Session["tid"] = tid;
                                    Session["department"] = department;
                                    Response.Redirect("Home_Teacher.aspx");
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password is incorrect.');", true);
                                }
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Teacher ID is not Registered. Please SignUp First');", true);
                            //Response.Redirect("Signup_Teacher.aspx");
                        }

                    }
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
    }
}