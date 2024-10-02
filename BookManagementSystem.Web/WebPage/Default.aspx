<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookManagementSystem.Web._Default" %>

<asp:Content ID="BodyContent" MasterPageFile="~/Site.Master" ContentPlaceHolderID="MainContent" runat="server">

   
    <div class="row Container">
        <h1 class="heading">Book Management System</h1>
        <div class="nav-link">
            <a class="nav-link1" runat="server" href="~/FirstPage">ADD BOOK</a>
            <a class="nav-link1" runat="server" href="~/ViewPage">VIEW BOOK</a>
        </div>
    </div>
</asp:Content>