<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginWithCookies.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
</head>
<body>
    <form id="formLogin" runat="server">
    <div>
        <asp:Label runat="server" ID="LabelLogin" Text="Login:"></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxLogin"></asp:TextBox>
        <asp:Button runat="server" ID="ButtonLogin" OnClick="ButtonLogin_Click" Text="Login"/>
    </div>
    </form>
</body>
</html>
