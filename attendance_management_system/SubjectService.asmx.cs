using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace attendance_management_system
{
    /// <summary>
    /// Summary description for SubjectService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SubjectService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public List<string> GetSubjectsBySemester(int semester)
        {
            // Simulate database query to retrieve subjects based on the selected semester
            // Replace this with your actual database query
            List<string> subjects = new List<string>();
            List<string> selected_subject = new List<string>();
            string department = Session["department"].ToString();
            string str_tid = Session["tid"].ToString();
            Int32 tid = Int32.Parse(str_tid);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["studentConnection"].ConnectionString;
           

            try
            {
                using (con)
                {
                    string query = "SELECT subject_name  FROM Subject WHERE semester = (@sem) AND department = (@dep)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@sem", semester);
                        cmd.Parameters.AddWithValue("@dep", department);
                        cmd.Connection = con;
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string name = reader.GetString(0);
                                subjects.Add(name);
                            }
                        }
                        con.Close();
                    }
                    //query = "SELECT subject_ID FROM Teaching WHERE subject_ID = (@sub_id)";
                    //using (SqlCommand cmd = new SqlCommand(query))
                    //{
                    //    cmd.Parameters.AddWithValue("@sub_id", tid);
                    //    cmd.Connection = con;
                    //    con.Open();
                    //    SqlDataReader reader = cmd.ExecuteReader();
                    //    if (reader.HasRows)
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            string name = reader.GetString(0);
                    //            selected_subject.Add(name);
                    //        }
                    //    }
                    //    con.Close();
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //subjects = subjects.Except(selected_subject).ToList();
            //foreach (string sl2 in selected_subject)
            //{
            //    subjects.Remove(sl2);
            //}
            //foreach (var subject in subjects)
            //{
            //    Debug.WriteLine(subject);
            //}
            //Debug.WriteLine(r);
            return subjects;
        }
    }
}
