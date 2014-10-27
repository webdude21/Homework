<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="Chat.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chat</title>
</head>
<body>
    <form id="formChat" runat="server">
    <div>
        <asp:UpdatePanel ID="UpdatePanelChat" runat="server">
            <asp:ListView runat="server" ID="ListViewChat" SelectMethod="ListViewChat_Select"></asp:ListView>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
