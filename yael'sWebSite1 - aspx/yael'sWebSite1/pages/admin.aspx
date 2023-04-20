<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="pages_admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Admin</h1>
    <div>
        <form runat="server">
            <label>name: </label>
            <input type="text" id="searchName" name="searchName" />
            <input type="button" value="search" runat="server" id="btnSearch" name="btnSearch" onserverclick="ClickSearch" />
            <br /><br />      
            <select id="columns" name="columns" runat="server">
                <option value="empty" selected>pick a column</option>
                <option value="username">username</option>
                <option value="mail">email</option>
                <option value="birth">birth</option>  
                <option value="phone">phone</option>  
            </select>
            <input type="radio" id="ASC" value="ASC" checked runat="server" /><label>ASC</label>
            <input type="radio" id="DESC" value="DESC" runat="server" /><label>DESC</label>
            <input type="button" value="Sort by" runat="server" id="btnSort" name="btnSort" onserverclick="ClickSort" />  
            <br />
            <input type="button" value="Delete" id="delete" name="delete" runat="server" onserverclick="DeleteUsers"/>
            <div style="text-align:center" id="Div1" runat="server"></div>
        </form>
    </div>
     <div style="text-align:center" id="showUsersTable" runat="server"></div>

</asp:Content>

