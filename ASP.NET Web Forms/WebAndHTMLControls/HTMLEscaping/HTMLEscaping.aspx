<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HTMLEscaping.aspx.cs" Inherits="HTMLEscaping.HTMLEscaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 { }
    </style>
</head>
<body>
    <form id="someForm" runat="server">
    <div class="auto-style1">
        <asp:Label ID="InputBoxLabel"  runat="server" Text="Input:"></asp:Label>
        <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonShowOutput" runat="server" OnClick="ButtonShowOutput_Click" Text="Go" />
        <asp:TextBox ID="TextBoxOutput" runat="server" Height="22px"></asp:TextBox>
        <asp:Label ID="LabelOutput" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
