using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_Update : System.Web.UI.Page
{
    public bool Authentication(string username2, string password2)
    {
        string sql = string.Format("SELECT admin FROM userTbl WHERE username='{0}' AND password='{1}'", username2, password2);
        object scalar = Helper.GetScalar(sql);
        if (scalar != null)
            return true;
        return false;
    }
    public void Edit(string[] columns, string[] arr)
    {
        string sql = "UPDATE " + Helper.tblName + " SET ";
        for (int i = 1; i < arr.Length; i++)
        {
            if (!arr[i].Equals(""))
                sql += columns[i] + "=\'" + arr[i] + "\',";
        }
        sql = sql.Substring(0, sql.Length - 1) + " WHERE username=\'" + arr[0] + "\'";
        int n = Helper.ExecuteNonQuery(sql);
        //Response.Write("Rows updated = " + n + "<br />");
        if (n > 0)
            Response.Write("User has been updated succesfully");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(bool)Session["login"])
           Response.Redirect("UnAuthorized.aspx");
    }
   
    
}