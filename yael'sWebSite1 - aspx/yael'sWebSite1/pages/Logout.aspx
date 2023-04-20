<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="pages_Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="style/StyleSheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
        <div><input type="button" value="יציאה" name="logout" id="logout" onserverclick="Logout"/></div>
    </form>
</asp:Content>

