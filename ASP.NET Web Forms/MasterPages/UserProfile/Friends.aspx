<%@ Page Title="Friends Info" Language="C#" MasterPageFile="~/UserProfile.Master" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="UserProfile.PersonalInfo" %>
<asp:Content ID="FriendsHead" ContentPlaceHolderID="head" runat="server">
    <title>Friends</title>
</asp:Content>
<asp:Content ID="FriendsContent" ContentPlaceHolderID="MainContent" runat="server">
   <h1>List of friends: </h1>
    <ul>
       <li>Pesho</li>
       <li>Gosho</li>
       <li>Ivan</li>
   </ul>
</asp:Content>
