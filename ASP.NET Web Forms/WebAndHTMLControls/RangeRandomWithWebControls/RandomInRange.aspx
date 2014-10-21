<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomInRange.aspx.cs" Inherits="RangeRandomWithWebControls.Range" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="randomInRange" runat="server">
        <div>
            <asp:TextBox ID="fistNumber" runat="server"></asp:TextBox>
            <asp:TextBox ID="secondNumber" runat="server"></asp:TextBox>
            <asp:Button ID="getRandom" runat="server" Text="Get Random" OnClick="getRandom_Click" />
            <br />
            <asp:Label ID="LabelResult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
