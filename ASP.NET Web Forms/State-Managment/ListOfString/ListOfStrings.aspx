<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListOfStrings.aspx.cs" Inherits="ListOfString.ListOfStrings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formSome" runat="server">
    <div>
        <asp:TextBox runat="server" ID="TextBoxInput"></asp:TextBox>
        <asp:Button runat="server" ID="SubmitButton" OnClick="SubmitButton_Click" Text="Submit"/>
        <br />
        <asp:Label runat="server" ID="ResultLabel"></asp:Label>
    </div>
    </form>
</body>
</html>
