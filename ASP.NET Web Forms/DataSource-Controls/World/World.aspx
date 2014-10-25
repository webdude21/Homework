<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="World.aspx.cs" Inherits="World.World" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formWorld" runat="server">
        <div>
            <asp:EntityDataSource ID="EntityDataSourceContinents"
                runat="server" ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities" EnableFlattening="False"
                EntitySetName="continents">
            </asp:EntityDataSource>
            <asp:ListBox ID="ListBoxContinents" runat="server"
                DataSourceID="EntityDataSourceContinents"
                DataTextField="Name" DataValueField="ID" AutoPostBack="True"></asp:ListBox>
            <asp:EntityDataSource ID="EntityDataSourceCities"
                runat="server" ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities" EnableFlattening="False"
                EntitySetName="cities" EntityTypeFilter="city" Include="country" Where="it.CountryCode=@countryId" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
                <WhereParameters>
                    <asp:ControlParameter Name="countryId" ControlID="GridViewCountries" Type="String" />
                </WhereParameters>
            </asp:EntityDataSource>
            <asp:GridView ID="GridViewCountries"
                DataSourceID="EntityDataSourceCountries" runat="server"
                AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" PageSize="5" DataKeyNames="Code">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="Code" HeaderText="Code" ReadOnly="True" SortExpression="Code" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="ContinentId" HeaderText="ContinentId" SortExpression="ContinentId" />
                    <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                    <asp:BoundField DataField="SurfaceArea" HeaderText="SurfaceArea" SortExpression="SurfaceArea" />
                    <asp:BoundField DataField="IndepYear" HeaderText="IndepYear" SortExpression="IndepYear" />
                    <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                    <asp:BoundField DataField="LifeExpectancy" HeaderText="LifeExpectancy" SortExpression="LifeExpectancy" />
                    <asp:BoundField DataField="GNP" HeaderText="GNP" SortExpression="GNP" />
                    <asp:BoundField DataField="GNPOld" HeaderText="GNPOld" SortExpression="GNPOld" />
                    <asp:BoundField DataField="LocalName" HeaderText="LocalName" SortExpression="LocalName" />
                    <asp:BoundField DataField="GovernmentForm" HeaderText="GovernmentForm" SortExpression="GovernmentForm" />
                    <asp:BoundField DataField="HeadOfState" HeaderText="HeadOfState" SortExpression="HeadOfState" />
                    <asp:BoundField DataField="Capital" HeaderText="Capital" SortExpression="Capital" />
                    <asp:BoundField DataField="Code2" HeaderText="Code2" SortExpression="Code2" />
                </Columns>
            </asp:GridView>
            <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server"
                ConnectionString="name=WorldEntities" DefaultContainerName="WorldEntities"
                EnableFlattening="False" EntitySetName="countries" Where="it.ContinentId=@ContId" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
                <WhereParameters>
                    <asp:ControlParameter ControlID="ListBoxContinents" Name="ContId" Type="Int32" />
                </WhereParameters>
            </asp:EntityDataSource>
            <asp:ListView ID="ListViewCities" runat="server"
                DataSourceID="EntityDataSourceCities"
                ItemType="World.Data.city"
                DataKeyNames="ID" InsertItemPosition="LastItem">
                <AlternatingItemTemplate>
                    <li style="">ID:
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                        <br />
                        Name:
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                        CountryCode:
                        <asp:Label ID="CountryCodeLabel" runat="server" Text='<%# Eval("CountryCode") %>' />
                        <br />
                        District:
                        <asp:Label ID="DistrictLabel" runat="server" Text='<%# Eval("District") %>' />
                        <br />
                        Population:
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </li>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <li style="">ID:
                        <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                        <br />
                        Name:
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        <br />
                        CountryCode:
                        <asp:TextBox ID="CountryCodeTextBox" runat="server" Text='<%# Bind("CountryCode") %>' />
                        <br />
                        District:
                        <asp:TextBox ID="DistrictTextBox" runat="server" Text='<%# Bind("District") %>' />
                        <br />
                        Population:
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </li>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    No data was returned.
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <li style="">ID:
                        <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                        <br />
                        Name:
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        <br />
                        CountryCode:
                        <asp:TextBox ID="CountryCodeTextBox" runat="server" Text='<%# Bind("CountryCode") %>' />
                        <br />
                        District:
                        <asp:TextBox ID="DistrictTextBox" runat="server" Text='<%# Bind("District") %>' />
                        <br />
                        Population:
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </li>
                </InsertItemTemplate>
                <ItemSeparatorTemplate>
                    <br />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <li style="">ID:
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                        <br />
                        Name:
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                        CountryCode:
                        <asp:Label ID="CountryCodeLabel" runat="server" Text='<%# Eval("CountryCode") %>' />
                        <br />
                        District:
                        <asp:Label ID="DistrictLabel" runat="server" Text='<%# Eval("District") %>' />
                        <br />
                        Population:
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </li>
                </ItemTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server" style="">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                    <div style="">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <li style="">ID:
                        <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                        <br />
                        Name:
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                        CountryCode:
                        <asp:Label ID="CountryCodeLabel" runat="server" Text='<%# Eval("CountryCode") %>' />
                        <br />
                        District:
                        <asp:Label ID="DistrictLabel" runat="server" Text='<%# Eval("District") %>' />
                        <br />
                        Population:
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </li>
                </SelectedItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
