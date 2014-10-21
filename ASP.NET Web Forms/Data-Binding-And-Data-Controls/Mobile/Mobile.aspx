<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mobile.aspx.cs" Inherits="Mobile.Mobile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile</title>
</head>
<body>
    <form id="mobileForm" runat="server">
        <div>
            <asp:Label ID="LabelProducer" runat="server" Text="Producer:"></asp:Label>
            <asp:DropDownList ID="DropDownListProducer"
                AppendDataBoundItems="False"
                OnSelectedIndexChanged="ProducersList_SelectedIndexChanged"
                DataTextField="Name" DataMember="Name"
                runat="server" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <asp:Label ID="LabelModel" runat="server" Text="Model:"></asp:Label>
            <asp:DropDownList ID="DropDownModels" AppendDataBoundItems="False" runat="server" DataTextField="Name" DataMember="Name">
            </asp:DropDownList>
            <br />
            <asp:Label ID="LabelEngines" runat="server" Text="Engine:"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonListEngines" runat="server" RepeatDirection="Horizontal">
            </asp:RadioButtonList>
            <asp:Label ID="LabelExtras" runat="server" Text="Extras:"></asp:Label>
            <asp:CheckBoxList ID="CheckBoxListExtras" runat="server" DataTextField="Name" DataMember="Name" RepeatDirection="Horizontal">
            </asp:CheckBoxList>
            <asp:Button ID="FormSubmiter" runat="server" Text="Submit" OnClick="FormSubmiter_Click"/>
        </div>
    </form>
    <asp:Literal ID="LiteralResult" runat="server"></asp:Literal>
</body>
</html>
