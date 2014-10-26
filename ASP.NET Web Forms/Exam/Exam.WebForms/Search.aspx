<%@ Page Title="Search Results for Query " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Exam.WebForms.Search" %>

<asp:Content ID="ContentSearch" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <h1><%: this.Title %>
            <asp:Literal runat="server" ID="LiteralSearchQuery" Mode="Encode"></asp:Literal>
        </h1>
    </div>
    <asp:Repeater runat="server" ID="SearchResultsRepeater" ItemType="Exam.WebForms.Models.Book" SelectMethod="SearchResultsRepeater_GetData">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink runat="server" NavigateUrl='<%#:"BookDetails.aspx?id=" + Item.ID %>'>
                                "<%#: Item.Title %>" <i>by <%#: Item.Author %></i>
                </asp:HyperLink>
                (Category: <%#: Item.Category.Name %>)
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <div class="back-link">
        <a href="/">Back To Books</a>
    </div>

</asp:Content>
