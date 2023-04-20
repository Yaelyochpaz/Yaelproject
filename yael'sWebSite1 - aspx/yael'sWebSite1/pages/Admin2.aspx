<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin2.aspx.cs" Inherits="pages_Admin2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Admin2</h1>
    <% Response.Write("Admin visitors:   " + Application["AdminVisitors"] + "</br></br>"); %>
   <%Response.Write("Logged in visitors: " + Application["GuestVisitors"] + "</br></br>"); %>
   <%Response.Write("Overall visitors: " + Application["SignedInVisitors"] + "</br></br>"); %>
   <%Response.Write("Current Admin visitors: " +  Application["currentAdminVisitors"] + "</br></br>"); %>
   <%Response.Write("Current Logged in visitors: " + Application["currentGuestVisitors"] + "</br></br>"); %>
   <%Response.Write("Overall current vistors: " + Application["currentVisitors"] + "</br></br>"); %>
</asp:Content>

