<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Exam.WebForms.Home" %>

<asp:Content ID="ContentHome" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1><%: this.Title %></h1>
        <div class="col-lg-4 pull-right">
            <asp:TextBox runat="server" ID="TextBoxSearch"></asp:TextBox>
            <asp:Button runat="server" CssClass="btn" Text="Search" OnClick="SearchButton_OnClick"/>
        </div>
    </div>
    <div class="row">
        <asp:ListView runat="server" ID="ListViewCategories" SelectMethod="Select_Categories"
            ItemType="Exam.WebForms.Models.Category" GroupItemCount="3">
            <GroupTemplate>
                <div class="row">
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                </div>
            </GroupTemplate>
            <ItemTemplate>
                <div class="col-md-4">
                    <h3><%#: Item.Name %></h3>
                    <ul>
                        <asp:ListView runat="server" ID="ListViewBooks" ItemType="Exam.WebForms.Models.Book" DataSource='<%# Item.Books %>'>
                            <ItemTemplate>
                                <li>
                                    <asp:HyperLink NavigateUrl='<%#:"BookDetails.aspx?id=" + Item.Id %>' runat="server">
                                              "<%#:Item.Title %>" by <i><%#: Item.Author %></i>
                                    </asp:HyperLink>
                                </li>
                            </ItemTemplate>
                        </asp:ListView>
                    </ul>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
