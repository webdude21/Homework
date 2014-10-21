<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomInRange.aspx.cs" Inherits="RangeRandom.RandomInRange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="randomRange" runat="server">
    <div>
        <input type="number" id="firstNumber" name="firstNumber" runat="server" />
        <input type="number" id="secondNumber" name="secondNumber" runat="server" />
        <input type="submit" value="GetRandom" onserverclick="ButtonClick" runat="server"/>
        <label id="result" runat="server"></label>
    </div>
    </form>
</body>
</html>
