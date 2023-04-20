using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_recover : System.Web.UI.Page
{
    /* public void ValidateDetails(string username3, string hintAns)
     {
         string sql1 = string.Format("SELECT password FROM userTbl WHERE username='{0}' AND hintAns= '{1}'" , username3, hintAns);
         object scalar = Helper.GetScalar(sql1);
         if (scalar != null)
         {
             Response.Write("Your password is: " + scalar.ToString());
         }
         else
         {
             Response.Write("Worng Answer");
         }

     }
    */
    public static string message = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["submit"] != null)
        {
            string username3 = Request.Form["username3"];
            string hintAns = Request.Form["hintAns"];
            string query = string.Format("SELECT password FROM userTbl WHERE username='{0}' AND hintAns= '{1}'", username3, hintAns);
            bool found = Helper.IsExist(query);
            string password = "";
            if (found)
            {
                password = Helper.ShowPassword(query);
                message = "Your password" + password;
            }
            else
            {
                message = "Worng Answer";
            }

        }
    }
}