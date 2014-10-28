<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateGridView.aspx.cs" Inherits="EmployeeOrders.UpdateGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 55px;
            height: 42px;
        }
    </style>
</head>
<body>
    <form id="formOrders" runat="server">
        <asp:UpdatePanel ID="UpdatePanelOrders" runat="server">
            <ContentTemplate>
                <asp:GridView runat="server" ID="EmployeesGrid" AutoGenerateColumns="False" DataKeyNames="EmployeeID"
                    DataSourceID="EmployeesDataSource" AllowPaging="True" AllowSorting="True">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                        <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" SortExpression="EmployeeID" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
                    </Columns>
                </asp:GridView>
                <asp:ScriptManager ID="ScriptManagerGridView" runat="server">
                </asp:ScriptManager>
                <asp:EntityDataSource ID="EmployeesDataSource" runat="server"
                    ConnectionString="name=NorthwindEntities" DefaultContainerName="NorthwindEntities"
                    EnableDelete="True" EnableFlattening="False" EnableInsert="True"
                    EnableUpdate="True" EntitySetName="Employees" Include="Orders">
                </asp:EntityDataSource>
                </div>

                <asp:GridView ID="GridViewOrders" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                    OnLoad="GridViewOrders_Load" DataKeyNames="OrderID" DataSourceID="OrdersDataSource">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" SortExpression="OrderID" />
                        <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
                        <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID" />
                        <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                        <asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" SortExpression="RequiredDate" />
                        <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate" />
                        <asp:BoundField DataField="ShipVia" HeaderText="ShipVia" SortExpression="ShipVia" />
                        <asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight" />
                        <asp:BoundField DataField="ShipName" HeaderText="ShipName" SortExpression="ShipName" />
                        <asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" SortExpression="ShipAddress" />
                        <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" SortExpression="ShipCity" />
                        <asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion" SortExpression="ShipRegion" />
                        <asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode" SortExpression="ShipPostalCode" />
                        <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry" />
                    </Columns>
                </asp:GridView>
                <asp:EntityDataSource ID="OrdersDataSource" runat="server" ConnectionString="name=NorthwindEntities"
                    DefaultContainerName="NorthwindEntities" EnableFlattening="False" EntitySetName="Orders"
                    Where="it.EmployeeID=@EmployeeID">
                    <WhereParameters>
                        <asp:ControlParameter Name="EmployeeID" ControlID="EmployeesGrid" Type="Int32" />
                    </WhereParameters>
                </asp:EntityDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row ">
            <asp:UpdateProgress ID="UpdateProgressOrders" AssociatedUpdatePanelID="UpdatePanelOrders" runat="server" DisplayAfter="1">
                <ProgressTemplate>
                    <img alt="Loading..." class="auto-style1" longdesc="Loading data ..." src="ajax-loader.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </form>
</body>
</html>
