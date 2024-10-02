<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="ViewPage.aspx.cs" Inherits="BookManagementSystem.Web.WebPage.ViewPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="gridbook">
       
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <asp:Button class="button" Text="HOME" runat="server" PostBackUrl="~/Default.aspx" />
        <asp:Button class="button" Text="Add Book" runat="server" PostBackUrl="~/FirstPage.aspx" />
        <div>
            <h2 class="heading-h1">Book List</h2>
            <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False" OnRowCommand="gvBooks_RowCommand" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                    <asp:BoundField DataField="AuthorName" HeaderText="Author Name" />
                    <asp:BoundField DataField="BookCount" HeaderText="Book Count" />
                    <asp:BoundField DataField="PublicationYear" HeaderText="Publication Year" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="Language" HeaderText="Language" />
                    <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="EditBook" />
                    <asp:ButtonField ButtonType="Button" Text="Delete"  CommandName="DeleteBook" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>