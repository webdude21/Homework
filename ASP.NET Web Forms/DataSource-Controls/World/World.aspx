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
                DataTextField="Name" DataValueField="ID" AutoPostBack="True">
            </asp:ListBox>
            <asp:EntityDataSource ID="EntityDataSourceCities" runat="server" ConnectionString="name=WorldEntities" DefaultContainerName="WorldEntities" EnableFlattening="False" EntitySetName="cities">
            </asp:EntityDataSource>
            <asp:GridView ID="GridViewCountries"
                DataSourceID="EntityDataSourceCountries" runat="server"
                AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" PageSize="5">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                    <asp:BoundField DataField="Region" HeaderText="Region" ReadOnly="True" SortExpression="Region" />
                    <asp:BoundField DataField="SurfaceArea" HeaderText="SurfaceArea" ReadOnly="True" SortExpression="SurfaceArea" />
                    <asp:BoundField DataField="IndepYear" HeaderText="IndepYear" ReadOnly="True" SortExpression="IndepYear" />
                    <asp:BoundField DataField="Population" HeaderText="Population" ReadOnly="True" SortExpression="Population" />
                    <asp:BoundField DataField="LifeExpectancy" HeaderText="LifeExpectancy" ReadOnly="True" SortExpression="LifeExpectancy" />
                    <asp:BoundField DataField="GNP" HeaderText="GNP" ReadOnly="True" SortExpression="GNP" />
                    <asp:BoundField DataField="LocalName" HeaderText="LocalName" ReadOnly="True" SortExpression="LocalName" />
                    <asp:BoundField DataField="GovernmentForm" HeaderText="GovernmentForm" ReadOnly="True" SortExpression="GovernmentForm" />
                    <asp:BoundField DataField="HeadOfState" HeaderText="HeadOfState" ReadOnly="True" SortExpression="HeadOfState" />
                    <asp:BoundField DataField="Capital" HeaderText="Capital" ReadOnly="True" SortExpression="Capital" />
                    <asp:BoundField DataField="Code2" HeaderText="Code2" ReadOnly="True" SortExpression="Code2" />
                </Columns>
            </asp:GridView>
            <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server"
                ConnectionString="name=WorldEntities" DefaultContainerName="WorldEntities"
                EnableFlattening="False" EntitySetName="countries" Where="it.ContinentId=@ContId">
                <WhereParameters>
                    <asp:ControlParameter ControlID="ListBoxContinents" Name="ContId" Type="Int32" />
                </WhereParameters>
            </asp:EntityDataSource>
            <asp:ListView ID="ListViewCities" runat="server" DataSourceID="EntityDataSourceCities" ItemType="World.Data.city" DataKeyNames="ID">
                <AlternatingItemTemplate>
                    <span style="">ID:
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
                    country:
                    <asp:Label ID="countryLabel" runat="server" Text='<%# Eval("country") %>' />
                    <br />
<br /></span>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <span style="">ID:
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
                    country:
                    <asp:TextBox ID="countryTextBox" runat="server" Text='<%# Bind("country") %>' />
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    <br /><br /></span>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <span>No data was returned.</span>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <span style="">ID:
                    <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                    <br />Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />CountryCode:
                    <asp:TextBox ID="CountryCodeTextBox" runat="server" Text='<%# Bind("CountryCode") %>' />
                    <br />District:
                    <asp:TextBox ID="DistrictTextBox" runat="server" Text='<%# Bind("District") %>' />
                    <br />Population:
                    <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    <br />country:
                    <asp:TextBox ID="countryTextBox" runat="server" Text='<%# Bind("country") %>' />
                    <br />
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    <br /><br /></span>
                </InsertItemTemplate>
                <ItemTemplate>
                    <span style="">ID:
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
                    country:
                    <asp:Label ID="countryLabel" runat="server" Text='<%# Eval("country") %>' />
                    <br />
<br /></span>
                </ItemTemplate>
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
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
                    <span style="">ID:
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
                    country:
                    <asp:Label ID="countryLabel" runat="server" Text='<%# Eval("country") %>' />
                    <br />
<br /></span>
                </SelectedItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
