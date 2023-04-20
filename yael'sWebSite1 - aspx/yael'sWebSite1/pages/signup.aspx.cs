using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_signup : System.Web.UI.Page
{
    public void SignUp()
    {
        string sql = string.Format("SELECT COUNT(username) FROM userTbl WHERE username='{0}'", Request.Form["username"]);
        int count = (int)Helper.GetScalar(sql);
        if (count > 0)
            Response.Write("This username is already taken");
        else
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            string firstname = Request.Form["firstname"];
            string lastname = Request.Form["lastname"];
            string name = firstname + " " + lastname;
            string mail = Request.Form["mail"];
            int gender;
            if (Request.Form["gender"].Equals("זכר"))
                gender = 1;
            else
                gender = 2;
            //string ConfirmPass = Request.Form["ConfirmPass"];
            string phone = Request.Form["phone"];
            string[] birthday = Request.Form["birth"].Split('-');
            int day = Convert.ToInt32(birthday[0]);
            int month = Convert.ToInt32(birthday[1]);
            int year = Convert.ToInt32(birthday[2]);
            DateTime birth = new DateTime(day, month, year);
            bool admin = false;
            string hintQ = Request.Form["hintQ"];
            string hintAns = Request.Form["hintAns"];
            User user = new User(username, password, name, mail, gender, phone, birth, admin, hintQ, hintAns);
            Helper.Insert(user);
            Response.AddHeader("REFRESH", "2;URL=login.aspx");
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}