using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance_management_system
{
    public partial class Login_Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;

            string student_ID = loginIdTextBox.Text;
            string dob = loginDobTextBox.Text;


            string query = "SELECT student_ID, dob FROM Student WHERE student_ID = (@student_id)";
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@student_id", student_ID);
                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string sid = reader.GetString(0);
                                string dateob = reader.GetString(1);

                                if (dateob == dob)
                                {
                                    Session["sid"] = sid;
                                    Response.Redirect("HomePage.aspx");
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password is incorrect.');", true);
                                }
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Student ID is not Registered. Please SignUp First');", true);
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student ID is not Registered. Please SignUp First')", true);
                            //Response.Redirect("Signup_Student.aspx");
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