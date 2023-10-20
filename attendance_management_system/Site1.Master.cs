using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace attendance_management_system
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected string isLogined { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //string id = IsUserAuthenticated();
            //if (id != "false")
            //{
            //    Console.WriteLine("Hi");
            //    isLogined = "212cc";
            //}
        }
        protected string IsUserAuthenticated()
        {
            if (Session["sid"] != null)
            {
                return "false";
            }
            return Session["sid"].ToString();
        }
    }
}