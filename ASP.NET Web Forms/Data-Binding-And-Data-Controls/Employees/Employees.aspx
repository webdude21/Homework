<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="Employees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
</head>
<body>
    <form id="employeesForm" runat="server">
        <div>
            <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False" ItemType="NorthwindData.Employee">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="EmployeeID"
                        DataNavigateUrlFormatString="EmpDetails.aspx?id={0}"
                        InsertVisible="False" Text="Edit" />
                    <asp:BoundField DataField="FirstName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="TitleOfCourtesy" HeaderText="Title Of Courtesy" SortExpression="TitleOfCourtesy" />
                    <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" SortExpression="BirthDate" />
                    <asp:BoundField DataField="HireDate" HeaderText="Hire Date" SortExpression="HireDate" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
