<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Exam.WebForms.Books" %>

<asp:Content ID="ContentBooks" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h1><%: this.Title %></h1>
        <div class="pull-right">
            <div class="form-control">
                <asp:TextBox runat="server" ID="TextBoxSearch"></asp:TextBox>
                <asp:LinkButton runat="server" ID="LinkButtonSearch" OnClick="SearchButton_Click">Search</asp:LinkButton>
            </div>
        </div>
    </div>
    <asp:ListView ID="ListViewCategory" runat="server"
        ItemType="Exam.WebForms.Models.Category"
        SelectMethod="ListViewCategories_GetData" GroupItemCount="3">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-4">
                <h2><%#: Item.Name %></h2>
                <asp:Repeater runat="server" ID="RepeaterBooks"
                    ItemType="Exam.WebForms.Models.Book" DataSource='<%# Item.Books %>'>
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink runat="server" NavigateUrl='<%#:"BookDetails.aspx?id=" + Item.ID %>'>
                                <%#: Item.Title %>  <i> by<%#: Item.Author %></i>
                            </asp:HyperLink> <%#: Item.Category.Name %>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
