<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SimpleHello.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="helloToYou" runat="server">
    <div>
    
        <asp:Label ID="LabelName" runat="server" Text="Enter Your Name:"></asp:Label>
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonShowHello" runat="server" OnClick="ButtonShowHello_Click" Text="Go" />
        <br />
        <asp:Label ID="ResultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
