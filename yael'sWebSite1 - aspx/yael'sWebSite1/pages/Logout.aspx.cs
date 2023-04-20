using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_Logout : System.Web.UI.Page
{
    public void Logout(object sender, EventArgs e)
    {
        /*
        if (Request.Form["button"] != null)
        {
            Session["username2"] = "guest";
            Session["login"] = false;
            if ((int)Application["currentVisitors"] > 0)
                Application["currentVisitors"] = (int)Application["currentVisitors"] - 1;
            Session["admin"] = false;
            Session["Admin2"] = false;
            Response.Write("You have logged out");
        }
        */
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            //Session.Clear();
            Session.Abandon();
            Response.Redirect("homePage.aspx");
            Session["tried"] = null;
        }
    }
}