<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesRepeater.aspx.cs" Inherits="EmployeesWithRepeater.EmployeesRepeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees with repeater</title>
</head>
<body>
    <form id="employeesRepeater" runat="server">
        <div>
            <table>
                <asp:Repeater ID="RepeaterEmployees" runat="server" ItemType="NorthwindData.Employee">
                    <HeaderTemplate>
                        <thead>
                            <tr>
                                <th>First Name</th>
                                <th>Last Name</th>
                                <th>Birth Date</th>
                                <th>City</th>
                                <th>Address</th>
                                <th>Country</th>
                                <th>HireDate</th>
                                <th>Notes</th>
                                <th>Title</th>
                                <th>Title Of Courtesy</th>
                                <th>Postal Code</th>
                            </tr>
                        </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.FirstName %></td>
                            <td><%#: Item.LastName %></td>
                            <td><%#: Item.BirthDate %></td>
                            <td><%#: Item.City %></td>
                            <td><%#: Item.Address %></td>
                            <td><%#: Item.Country %></td>
                            <td><%#: Item.HireDate %></td>
                            <td><%#: Item.Notes %></td>
                            <td><%#: Item.Title%></td>
                            <td><%#: Item.TitleOfCourtesy%></td>
                            <td><%#: Item.PostalCode%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
