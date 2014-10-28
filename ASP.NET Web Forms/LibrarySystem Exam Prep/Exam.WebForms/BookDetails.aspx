<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="Exam.WebForms.BookDetails" %>

<asp:Content ID="ContentBookDetails" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1><%: this.Title %></h1>
    </div>
    <div class="row">
        <asp:FormView runat="server" ItemType="Exam.WebForms.Models.Book" SelectMethod="FormViewBook_Select">
            <ItemTemplate>
                <h3><%#: Item.Title %></h3>
                <p>by <i><%#: Item.Author %></i></p>
                <p visible='<%#Eval("ISBN") != null %>' runat="server">
                    <i>ISBN: <%#: Item.ISBN %></i>
                </p>
                <p visible='<%#Eval("WebSite") != null %>' runat="server">
                    <asp:HyperLink runat="server" NavigateUrl="<%#: Item.WebSite%>">
                        <%#: Item.WebSite%>
                    </asp:HyperLink>
                </p>
                <p><%#: Item.Description %></p>
            </ItemTemplate>
        </asp:FormView>
    </div>
    <div class="row">
        <div class="back-link">
            <a href="/">Back To Books</a>
        </div>
    </div>
</asp:Content>
