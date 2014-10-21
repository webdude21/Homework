<%@ Page Title="Personal Info" Language="C#" MasterPageFile="~/UserProfile.Master" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="UserProfile.PersonalInfo" %>
<asp:Content ID="PersonalInfoHead" ContentPlaceHolderID="head" runat="server">
    <title>Personal Info</title>
</asp:Content>
<asp:Content ID="PersonalInfoContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Personal Info:</h1>
    <h3>Name: Petar Georgiev</h3>
    <h3>Age: 32</h3>
    <h3>Interests: Cats</h3>
</asp:Content>
