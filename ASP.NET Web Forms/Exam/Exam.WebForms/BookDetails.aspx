<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="Exam.WebForms.BookDetails" %>

<asp:Content ID="ContentBookDetails" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: this.Title %></h1>
    <asp:FormView runat="server" ID="FormViewDetails" ItemType="Exam.WebForms.Models.Book" SelectMethod="FormViewDetails_GetItem">
        <ItemTemplate>
            <p><%#: Item.Title %></p>
            <p><i>by <%#: Item.Author %></i></p>
            <p><i>ISBN: <%#: Item.ISBN %></i></p>
            <p>
                <i>Web Site: 
                    <a href='<%# Item.WebSite %>'><%# Item.WebSite %></a>
                </i>
            </p>
            <div class="col-md-12"></div>
            <p><%#: Item.Description %></p>
        </ItemTemplate>
    </asp:FormView>
    <div class="back-link">
        <a href="/">Back To Books</a>
    </div>
</asp:Content>
