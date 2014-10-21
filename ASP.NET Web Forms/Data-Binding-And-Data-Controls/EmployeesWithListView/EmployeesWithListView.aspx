<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesWithListView.aspx.cs" Inherits="EmployeesWithListView.EmployeesWithListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="emplyeesWithListView" runat="server">
        <div>
            <table>
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
                <asp:ListView runat="server" ID="ListViewEmplyees" ItemType="NorthwindData.Employee">
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
                </asp:ListView>
            </table>
        </div>
    </form>
</body>
</html>
