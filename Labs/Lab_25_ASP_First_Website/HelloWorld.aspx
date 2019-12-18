<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="Lab_25_ASP_First_Website.HelloWorld" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Hello World</h1>
    
    <ul>
        <li>Yash</li>
        <li>Chatim</li>
    </ul>

    
    <asp:TextBox ID="TextBox1" runat="server">Text</asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <form method="get">
        First Name: <input type="text" placeholder="Name" />
                    <button type="submit" onclick="">Button</button>
    </form>
    
</asp:Content>
