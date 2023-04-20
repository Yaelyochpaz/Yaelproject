using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.ServiceModel.Channels;

public partial class pages_login : System.Web.UI.Page
{
    public void ValidateLogin(string username2, string password2)
    {
        string sql = String.Format("SELECT * FROM {0} WHERE username='{1}' AND password='{2}'", Helper.tblName, username2, password2);
        SqlConnection con = new SqlConnection(Helper.conString);
        SqlCommand cmd = new SqlCommand(sql, con);
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            Session["username2"] = username2;
            Session["login"] = true;
            Session["admin"] = (bool)reader.GetBoolean(7);
            Response.Redirect("homepage.aspx");
            if (reader.GetBoolean(12))
            {
                Session["type"] = 2;
                Application.Lock();
                Application["AdminVisitors"] = (int)Application["AdminVisitors"] + 1;
                Application["SignedInVisitors"] = (int)Application["SignedInVisitors"] + 1;
                Application["currentSignedInVisitors"] = (int)Application["currentSignedInVisitors"] + 1;
                Application["currentAdminVisitors"] = (int)Application["currentAdminVisitors"] + 1;
                Application.UnLock();
                Response.Write(" You are admin! ");
            }
            else
            {
                Session["type"] = 1;
                Response.Write(" You are not admin! ");
                Application.Lock();
                Application["GuestVisitors"] = (int)Application["GuestVisitors"] + 1;
                Application["SignedInVisitors"] = (int)Application["SignedInVisitors"] + 1;
                Application["currentSignedInVisitors"] = (int)Application["currentSignedInVisitors"] + 1;
                Application["currentGuestVisitors"] = (int)Application["currentGuestVisitors"] + 1;
                Application.UnLock();
            }
        }

        else
        {
            Response.Write(" Unknown username   ");
            Session["count"] = (int)Session["count"] + 1;
            if ((int)Session["count"] > 3)
            {
                Response.Write("no more tries!");
                //  Session["user"] = Request.Form["userName"];
                Response.Redirect("recover.aspx");
                Session["count"] = 0;
                Session["login"] = false;
            }
            else
            {
                if ((int)Session["count"] == 2)
                {
                    Response.Write("you have " + (4 - (int)Session["count"]) + " more try!");
                }
                else
                {
                    Response.Write("you have " + (4 - (int)Session["count"]) + " more tries!");
                }
            }
        }
        reader.Close();
        con.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
        /* message.InnerHtml = "Username or password incorrect!";
             Session["count"] = (int)Session["count"] + 1;
             if ((int)Session["count"] > 3)
             {
                 Response.Write("no more tries!");
                 Response.Redirect("recover.aspx");
                 Session["count"] = 0;
                 Session["login"] = false;
             }
        
    
            else
            {
                if ((int)Session["count"] == 2)
                {
                    Response.Write("you have " + (4 - (int)Session["count"]) + " more try!");
                }
                else
                {
                    Response.Write("you have " + (4 - (int)Session["count"]) + " more tries!");
                }
            }
        }

        reader.Close();
        con.Close();
    }
    public bool Authentication(string username2, string password2)
    {
        string sql = string.Format("SELECT admin FROM userTbl WHERE username='{0}' AND password='{1}'", username2, password2);
        object scalar = Helper.GetScalar(sql);
        if (scalar != null)
        {
            Session["admin"] = (bool)scalar;
            Session["username"] = username2;
            Session["login"] = true;
            return true;
        }
        else
        {
            Session["count"] = (int)Session["count"] + 1;
        }
        return false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}*/
        