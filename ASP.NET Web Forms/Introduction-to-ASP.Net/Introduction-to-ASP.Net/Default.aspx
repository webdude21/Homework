<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Introduction_to_ASP.Net._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Label ID="LabelFirstNumber" runat="server" Text="First Numer:"></asp:Label>
        <asp:TextBox ID="TextBoxFirstNumber" runat="server" Width="226px"></asp:TextBox>
        <br />
        <asp:Label ID="LabelSecondNumber" runat="server" Text="Second Numer:"></asp:Label>
        <asp:TextBox ID="TextBoxSecondNumber" runat="server" Width="226px"></asp:TextBox>
        <asp:Button ID="ButtonSum" runat="server" OnClick="ButtonSum_Click" Text="Sum" />
        <br />
        <asp:Label ID="LabelResult" runat="server" Text="Result:"></asp:Label>
        <asp:TextBox ID="TextBoxResult" runat="server"></asp:TextBox>
    </div>

    <div class="row">
    </div>

</asp:Content>
