<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="websites.aspx.cs" Inherits="pages_websites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>אתרים לצפייה</h1>
    <table align="center">
        <tr>
            <td>
                <img src="/img/net.jpg" width="400" height="250" />
            </td>
            <td align="right">
                <img src="/img/TU.jpg" width="400" height="250" />
            </td>
            <td align="right"> <img src="/img/dis.jpg" width="400" height="250" /> </td>

        </tr>
        <tr>
            <td align="right">
                <a style="color:black" href="https://www.netflix.com/il/"> <h2>NETFLIX</h2> </a>
            </td>
            <td align="right">
                <a style="color:black" href="https://tubitv.com/"> <h2>TUBI TV</h2> </a>
            </td>
            <td align="right">
                <a style="color:black" href="https://www.apps.disneyplus.com/il/onboarding"> <h2>DISNEY+</h2></a>
            </td>
        </tr>
    </table>

</asp:Content>

