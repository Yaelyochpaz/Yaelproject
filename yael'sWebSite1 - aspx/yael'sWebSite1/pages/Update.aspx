<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="pages_Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Update User</h1>
    <% Response.Write("User to edit is " + Session["username"]); %>
    <form runat="server" style="background-color:lightpink" align=center method="post" >     
        <br />
        <label>סיסמה ישנה:</label><input type="password" id="oldPassword" name="oldPassword" /><br />
        <label>סיסמה חדשה:</label><input type="password" id="newPassword" name="newPassword" /><br />
        <label>מייל:</label><input type="text" id="email" name="email" /><br />
        <label>תאריך לידה:</label><input type="date" id="birth" name="birth" /><br />
        <labal>מספר טלפון:</labal><input type="tel" id="phone" name="phone" /><br />
        <input type="submit" value="עדכן משתמש" id="submit" name="submit" /><br />
    </form>
    <div id="message" runat="server"></div>
    <%
        if (Request.Form["submit"] != null)
        {
            string oldPassword = Request.Form["oldPassword"];
            if (Authentication(Session["username"].ToString(), oldPassword))
            {
                string[] userToUpdate = { Session["username"].ToString(), Request.Form["newPassword"], Request.Form["email"], Request.Form["birth"], Request.Form["phone"] };
                string[] columns = { "username", "password", "email", "birth", "phone" };
                Edit(columns, userToUpdate);
            }
            else
                Response.Write("Invalid password. Update failed");    
            Response.Redirect("homepage.aspx");
        }
        

    %>
</asp:Content>

