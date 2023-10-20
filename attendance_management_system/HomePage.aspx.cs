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
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sid"]  != null)
            {
                string sid = Session["sid"] as string;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;

                string query = "SELECT * FROM Student WHERE student_ID = (@student_id)";
                try
                {
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@student_id", sid);
                            cmd.Connection = con;
                            con.Open();
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    lblSid.Text = reader.GetString(0);
                                    lblName.Text = reader.GetString(1);
                                    lblEmail.Text = reader.GetString(2);
                                    lblMobile.Text = reader.GetString(3);
                                    Int32 num = reader.GetInt32(4);
                                    lblSem.Text = num.ToString();
                                    lblDob.Text = reader.GetString(5);
                                    lblbranch.Text = reader.GetString(6);
                                }
                            }
                            else
                            {
                                Response.Write("No Data");
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
            else
            {
                Response.Redirect("Login_Student.aspx");
            }
        }
    }
}