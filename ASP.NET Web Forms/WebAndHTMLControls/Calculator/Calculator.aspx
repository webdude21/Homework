<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="calculator" runat="server">
        <div>
            <asp:TextBox ID="TextBoxResult" runat="server" Font-Strikeout="False" Style='text-align: right' Width="106px">0</asp:TextBox>
            <br />
            <asp:Button ID="ButtonOne" runat="server" Text="1" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonTwo" runat="server" Text="2" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonThree" runat="server" Text="3" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonPlus" runat="server" Text="+" OnClick="ButtonOperation_Click"/>
            <br />
            <asp:Button ID="ButtonFour" runat="server" Text="4" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonFive" runat="server" Text="5" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonSix" runat="server" Text="6" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonMinus" runat="server" Text="-" OnClick="ButtonOperation_Click" Width="22px" />
            <br />
            <asp:Button ID="ButtonSeven" runat="server" Text="7" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonEight" runat="server" Text="8" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonNine" runat="server" Text="9" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonMultiply" runat="server" Text="x" OnClick="ButtonOperation_Click" Width="22px" />
            <br />
            <asp:Button ID="ButtonClear" runat="server" Text="C" Width="22px" OnClick="ButtonClear_Click" />
            <asp:Button ID="ButtonZero" runat="server" Text="0" OnClick="ButtonDigit_Click" />
            <asp:Button ID="ButtonDivision" runat="server" Text="/" OnClick="ButtonOperation_Click" Width="22px" />
            <asp:Button ID="ButtonSquareRoot" runat="server" Text="√" OnClick="ButtonOperation_Click"/>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="ButtonEquals" runat="server" Text="=" Width="43px" OnClick="ButtonEquals_Click" />
            <br />
        </div>
    </form>
</body>
</html>
