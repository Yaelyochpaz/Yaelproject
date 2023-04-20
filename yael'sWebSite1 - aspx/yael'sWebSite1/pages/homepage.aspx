<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="homepage.aspx.cs" Inherits="pages_homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1 style="text-align:center; color:orangered;">
        <font size="150">
            TV RECOMMENDS
        </font>
         </h1>
     <style>
        .container {
            position: relative;
            width: 50%;
        }

        .image {
            display: block;
            width: 100%;
            height: auto;
        }

        .overlay {
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            height: 100%;
            width: 100%;
            opacity: 0;
            transition: .5s ease;
            background-color:deeppink;
        }

        .container:hover .overlay {
            opacity: 1;
        }

        .text {
            color: white;
            font-size: 20px;
            position: absolute;
            top: 50%;
            left: 50%;
            -webkit-transform: translate(-50%, -50%);
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
            text-align: center;
        }
    </style>

    <center>
    <div class="container">
        <img src="/img/file.png" alt="Avatar" class="image">
        <div class="overlay">
            <div class="text">WELCOME TO MY PAGE!</div>
        </div>
        </div>
        </center>


        <h2 style="text-align:center; color:orangered; font-size:30px">
            באתר תוכלו למצוא סדרות וסרטים שונים ומגוונים, שיוצרת האתר בחרה והמליצה מנסיונה האישי ומטעמה האישי.
        </h2>
        <h2 style="text-align:center; color:orangered; font-size:30px;">
            בנוסף באתר יש מגוון מידע על סדרות / סרטים כדי שתוכלו לבחור במה שמתאים לכם
        </h2>
        <h2 style="text-align:center; color:orangered; font-size:35px;">
           תהנו!
        </h2>
</asp:Content>

