<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="StudentRegistration.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 390px">
    <form id="registerStudent" runat="server">
    <div style="height: 316px">
    
        <asp:Panel ID="PanelRegister" runat="server" Height="435px">
            <asp:Label ID="LabelFirstName" runat="server" Text="First Name:"></asp:Label>
            <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelLastName" runat="server" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelFacultyNumber" runat="server" Text="Faculty Number:"></asp:Label>
            <asp:TextBox ID="TextBoxFacultyNumber" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelUniversity" runat="server" Text="University:"></asp:Label>
            <asp:DropDownList ID="DropDownListUniversity" runat="server" Height="27px" Width="213px">
                <asp:ListItem Value="SU">Софийски Универсистет</asp:ListItem>
                <asp:ListItem Value="TU">Технически Универсистет</asp:ListItem>
                <asp:ListItem>УНСС</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="LabelSpecialty" runat="server" Text="Specialty:"></asp:Label>
            <asp:DropDownList ID="DropDownListSpeciality" runat="server">
                <asp:ListItem>Компютърни Науки</asp:ListItem>
                <asp:ListItem>КСТ</asp:ListItem>
                <asp:ListItem>Комуникации</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Courses" runat="server" Text="Courses:"></asp:Label>
            <asp:ListBox ID="ListBoxCourses" runat="server" SelectionMode="Multiple" Width="114px">
                <asp:ListItem>ООП</asp:ListItem>
                <asp:ListItem>Java</asp:ListItem>
                <asp:ListItem>Алгоритми</asp:ListItem>
                <asp:ListItem>C#</asp:ListItem>
                <asp:ListItem>JavaScript</asp:ListItem>
            </asp:ListBox>
            <br />
            <br />
            <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmitClick" Text="Submit" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
