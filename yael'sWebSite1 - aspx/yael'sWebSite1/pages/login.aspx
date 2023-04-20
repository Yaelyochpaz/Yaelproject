<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="pages_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../js/JavaScriptlogin.js"></script>
</asp:Content>        
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1>כניסה</h1>
    <form dir="rtl" name="form1" onsubmit="return validateForm()" runat="server">

        <table style="background-color:lightpink"
               align=center>
            <tr>
                <td>
                    שם משתמש
                </td>
                <td><input type="text" name="username2" id="username2" onkeypress="checkUserName2('username2', 'errorUsername2')" /></td>
                <td><div id="errorUsername2"></div></td>
            </tr>
            <tr>
                <td>
                    סיסמא
                </td>
                <td><input type="password" name="password2" id="password2" onkeypress="checkPassword2('password2', 'errorPass2')" /></td>
                <td><div id="errorPass2"></div></td>
            </tr>
            <tr>
                <td><input type="submit" id="submit" name="submit" value="שלח" /></td>
                <td><input type="reset" value="ניקוי" /></td>
                 <td align="right">
                <a style="text-align:right" href="recover.aspx"> <h2>שחזור סיסמה</h2> </a>
            </td>
            </tr>
        </table>
    </form>
    <div id="message" runat="server"></div>
    <%
        //Response.Write(Request.Form["username"]);
        if (Request.Form["submit"] != null)
        {
            string username2 = Request.Form["username2"];
            string password2 = Request.Form["password2"];
             ValidateLogin(username2, password2);
            Session["username2"] = username2;
            Session["login"] = true;
            if (Request.Form["username2"].Equals("yaell1234!."))
            {
                Session["admin"] = true;
                Session["Admin2"] = true;
            }
            else
            {
                Session["admin"] = false;
                Session["Admin2"] = false;
            }
            //Response.Redirect("homepage.aspx");
        }
    %>
</asp:Content>

