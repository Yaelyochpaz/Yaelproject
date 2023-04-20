using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    /*
    public void Logout(object sender, EventArgs e)
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
   
    public string CurrentDate()
    {
        DateTime dt = DateTime.Now;
        string date = dt.ToString().Split(' ')[0];
        return date;
    }
    public string CurrentTime()
    {
        DateTime dt = DateTime.Now;
        string time = dt.ToString().Split(' ')[1];
        return time;
    }
    public string Message()
    {
       
        DateTime dt = DateTime.Now;
        //string hour = dt.ToString().Split(' ')[1].Split(':')[0];
        int hour = dt.Hour;

        string message = CurrentDate() + "<br />Good ";
        if (hour < 12)
            message += "moring";
        else if (hour < 17)
            message += "afternoon";
        else
            message += "evening";
        message += "<br />Dear ";
        
        message += Session["username2"];
        
        return message;
    }
    public string Hello()
    {
        return "Hello guest";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["admin"] == false)
            adminPage.Style.Add("visibility", "hidden");
        else
            adminPage.Style.Remove("visibility");

        if ((bool)Session["Admin2"] == false)
            Admin2Page.Style.Add("visibility", "hidden");
        else
            Admin2Page.Style.Remove("visibility");
       
    }
}
