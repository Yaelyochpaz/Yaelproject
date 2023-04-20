using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Logout(object sender, EventArgs e)
    {
        Session["username2"] = "guest";
        Session["login"] = false;
        if ((int)Application["activeUsers"] > 0)
            Application["activeUsers"] = (int)Application["activeUsers"] - 1;
        Session["admin"] = false;
        Response.Write("You have logged out");
    }
}