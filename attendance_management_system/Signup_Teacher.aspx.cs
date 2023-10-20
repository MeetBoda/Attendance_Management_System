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
    public partial class Signup_Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignupButton_Click(object sender, EventArgs e)
        {
            // Handle signup logic here
            string name = nameTextBox.Text;
            string dob = dobTextBox.Text;
            string mobile = mobileTextBox.Text;
            string email = emailTextBox.Text;
            string department = DropDownList2.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
            string query = "INSERT INTO Teacher (name, email_ID, mobile, dob, department) VALUES(@name, @email_ID, @mobile, @dob, @department)";
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email_ID", email);
                        cmd.Parameters.AddWithValue("@dob", dob);
                        cmd.Parameters.AddWithValue("@mobile", mobile);
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("Login_Teacher.aspx");
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