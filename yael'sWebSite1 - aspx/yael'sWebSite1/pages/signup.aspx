<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="pages_signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <script type="text/javascript" src="../js/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 style="text-align:center;color:orangered;">
        <font size="150">
            טופס הרשמה לאתר
        </font>
    </h1>

    <form dir="rtl" name="form1" onsubmit="return validateForm()" runat="server">

        <table style="background-color:lightpink"
               align=center>
            <tr>
                <td>
                    שם פרטי
                </td>
                <td><input type="text" name="firstname" id="firstname" onkeypress="checkFirstname('firstname', 'errorFN')" /></td>
                <td><div id="errorFN"></div></td>
            </tr>
            <tr>
                <td>
                    שם משפחה
                </td>
                <td><input type="text" name="lastname" id="lastname" onkeypress="checkLastname('lastname', 'errorLN')" /></td>
                <td><div id="errorLN"></div></td>
            </tr>
            <tr>
                <td>מין</td>
                <td>
                    <input type="radio" name="gender" value="male" onchange="checkGender('gender', 'errorGender')" />זכר
                    <input type="radio" name="gender" value="female" onchange="checkGender('gender', 'errorGender')" />נקבה
                <td>
                    <div id="errorGender"></div>
                </td>
            </tr>
            <tr>
                <td>
                    מייל
                </td>
                <td><input type="text" name="mail" id="mail" onkeypress="checkMail('mail', 'errorMail')" /></td>
                <td><div id="errorMail"></div></td>
            </tr>
            <tr>
                <td>
                    שם משתמש
                </td>
                <td><input type="text" name="username" id="username" onkeypress="checkUserName('username', 'errorUsername')" /></td>
                <td><div id="errorUsername"></div></td>
            </tr>
            <tr>
                <td>
                    סיסמא
                </td>
                <td><input type="password" name="password" id="password" oninput="checkPassword('password', 'errorPassword')" /></td>
                <td><div id="errorPassword"></div></td>
            </tr>

            <tr>
                <td>
                    אימות סיסמא
                </td>
                <td><input type="password" name="ConfirmPass" id="ConfirmPass" oninput="checkConfirmPass('password', 'ConfirmPass', 'errorConfirmPass')" /></td>
                <td><div id="errorConfirmPass"></div></td>
            </tr>

            <tr>
                <td>
                    מספר טלפון
                </td>
                <td><input type="tel" name="phone" id="phone" onkeypress="checkPhone('phone', 'errorPhone')" /></td>
                <td><div id="errorPhone"></div></td>
            </tr>

            <tr>
                <td>
                    תאריך לידה
                </td>
                <td><input type="date" name="birth" id="birth" onkeypress="checkBirth('birth', 'errorBirth')" /></td>
                <td><div id="errorBirth"></div></td>
            </tr>
            <tr>
                <td>
                    שאלת שיחזור סיסמא
                </td>
                <td>
                    <input type="text" onkeyup="checkHintAnswer('hintAns1', 'errorHintQuestion');" id="hintAns1" name="hintAns" placeholder="הכנס את תשובתך" />
                    <select id="hintQ" name="hintQ" onchange="return checkHintQuestion('hintQ', 'errorHintQuestion')" onkeyup="checkHintQuestion('hintQ', 'errorHintQuestion');">
                        <option value="" disabled selected hidden> </option>
                        <option value="1"> מה הצבע האהוב עליך</option>
                        <option value="2"> מה החיה האהובה עליך</option>
                    </select>
                    <div id="errorHintQuestion" class="error"></div>
                </td>
            </tr>
            <tr>
            <tr>
                <td>
                    שאלת שיחזור סיסמא
                </td>
                <td>
                    <input type="text" onkeyup="checkHintAnswer('hintAns2', 'errorHintQuestion');" id="hintAns2" name="hintAns" placeholder="הכנס את תשובתך" />
                    <select id="hintQ1" name="hintQ" onchange="checkHintQuestion('hintQ1', 'errorHintQuestion1')">
                        <option value="" disabled selected hidden> </option>
                        <option value="1"> מה תרצה לעשות שתהיה גדול</option>
                        <option value="2"> מה המאכל האהוב עלייך</option>
                    </select>
                    <div id="errorHintQuestion1" class="error"></div>
                </td>
            </tr>
            <tr>
                <td><input type="submit" id="submit" name="submit" value="שלח" /></td>
                <td><input type="reset" id="reset" name="reset" value="ניקוי" /></td>
            </tr>
        </table>
        </form>
   
     <%
         if (Request.Form["submit"] != null)
         {
             Response.Write("hi");
             SignUp();
         }
    %>
</asp:Content>

