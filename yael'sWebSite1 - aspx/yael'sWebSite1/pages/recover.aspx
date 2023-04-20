<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="recover.aspx.cs" Inherits="pages_recover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../js/jsrecover.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h1>שיחזור סיסמה</h1>
    <form dir="rtl" name="form1" onsubmit="return validateForm()" runat="server" action="" method="post">

        <table style="background-color:lightpink"
               align=center>
            <tr>
                <td>
                    שם משתמש
                </td>
                <td><input type="text" name="username3" id="username3" onkeypress="checkUserName3('username3', 'errorUsername3')" /></td>
                <td><div id="errorUsername3"></div></td>
            </tr>
            <tr>
                <td>
                    שאלת שיחזור סיסמא
                </td>
                <td>
                    <input type="text" onkeyup="checkHintAnswer('hintAns', 'errorHintQuestion');" id="hintAns" name="hintAns" placeholder="הכנס את תשובתך" />
                    <select id="hintQ" name="hintQ" onchange="return checkHintQuestion('hintQ', 'errorHintQuestion')" onkeyup="checkHintQuestion('hintQ', 'errorHintQuestion');">
                        <option value="" disabled selected hidden> </option>
                        <option value="color"> מה הצבע האהוב עליך</option>
                        <option value="closet"> מה החיה האהובה עליך</option>
                    </select>
                    <div id="errorHintQuestion" class="error"></div>
                </td>
            </tr>
            <tr>
                <td>
                    שאלת שיחזור סיסמא
                </td>
                <td>
                    <input type="text" onkeyup="checkHintAnswer('hintAns', 'errorHintQuestion');" id="hintAns1" name="hintAns1" placeholder="הכנס את תשובתך" />
                    <select id="hintQ1" name="hintQ" onchange="checkHintQuestion('hintQ1', 'errorHintQuestion1')">
                        <option value="" disabled selected hidden> </option>
                        <option value="color">מה תרצה לעשות שתהיה גדול</option>
                        <option value="closet"> מה המאכל האהוב עלייך</option>
                    </select>
                    <div id="errorHintQuestion1" class="error"></div>
                </td>
            </tr>
            <tr>
            <tr>
                <td><input type="submit" id="submit" name="submit" value="שלח"></td>
                <td><input type="reset" value="ניקוי"></td>

            </tr>
        </table>
       
    </form>
    
        <% = message %>
     
    
     <%--<%
         if (Request.Form["submit"] != null)
         {
             string username3 = Request.Form["username3"];
             string hintAns = Request.Form["hintAns"];
             ValidateDetails(username3, hintAns);
         }
         //Response.Redirect("login.aspx");
    %>--%>
</asp:Content>

