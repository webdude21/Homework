<%@ Page Title="Search Results for Query " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Exam.WebForms.Search" %>

<asp:Content ID="ContentSearch" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <h1><%: this.Title %>
            <asp:Literal runat="server" ID="LiteralSearchQuery" Mode="Encode"></asp:Literal>
        </h1>
    </div>
    <div class="row">
        <ul>
            <asp:ListView runat="server" ID="ListViewSearchResults" ItemType="Exam.WebForms.Models.Book" SelectMethod="ListView_SelectBooks">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink NavigateUrl='<%#:"BookDetails.aspx?id=" + Item.Id %>' runat="server">
                                              "<%#:Item.Title %>" by <i><%#: Item.Author %></i>
                        </asp:HyperLink>
                        (Category: <%#: Item.Category.Name %>)
                    </li>
                </ItemTemplate>
            </asp:ListView>
        </ul>
    </div>
    <div class="back-link">
        <a href="/">Back To Books</a>
    </div>
</asp:Content>
