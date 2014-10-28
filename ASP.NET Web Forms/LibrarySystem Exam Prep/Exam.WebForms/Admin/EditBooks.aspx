<%@ Page Title="EditBooks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="Exam.WebForms.Admin.Books" %>

<asp:Content ID="ContentEditBooks" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1><%: this.Title %></h1>
    </div>
    <div class="row">
        <asp:GridView runat="server" ItemType="Exam.WebForms.Models.Book" SelectMethod="GridViewBooks_Select"
            ID="GridViewBooks"
            UpdateMethod="GridViewBooks_Update" DeleteMethod="GridViewBooks_Delete"
            AllowPaging="True" AllowSorting="True" PageSize="5" AutoGenerateColumns="False" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                <asp:HyperLinkField DataTextField="WebSite" DataNavigateUrlFields="Website" HeaderText="WebSite" SortExpression="WebSite" />
                <asp:BoundField DataField="Category.Name" HeaderText="Category" SortExpression="Category.Name" />
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" HeaderText="Action" />
            </Columns>
        </asp:GridView>
    </div>
     <div runat="server" id="btnWrapper">
        <asp:LinkButton Text="Insert" ID="LinkButtonInsert" runat="server" OnClick="LinkButtonInsert_Click" />
    </div>

    <asp:UpdatePanel runat="server" ID="UpdatePanelInsertBook" CssClass="panel">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="LinkButtonInsert" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:FormView runat="server" ID="FormViewIsertBook" DefaultMode="Insert" ItemType="Exam.WebForms.Models.Book"
                InsertMethod="FormViewIsertBook_InsertItem" Visible="false">
                <InsertItemTemplate>
                    <h2>Create New Book</h2>
                    <div>
                        <span>Title:</span>
                        <asp:TextBox runat="server" ID="TextBoxBookTitleCreate" placeholder="Enter book title ..." Text=" <%#: BindItem.Title %>">                           
                        </asp:TextBox>
                    </div>
                    <div>
                        <span>Author(s):</span>
                        <asp:TextBox runat="server" ID="TextBoxAuthorCreate" placeholder="Enter book author / authors ..." Text=" <%#: BindItem.Author %>">                           
                        </asp:TextBox>
                    </div>
                    <div>
                        <span>ISBN:</span>
                        <asp:TextBox runat="server" ID="TextBoxISBNCreate" placeholder="Enter book ISBN ..." Text=" <%#: BindItem.ISBN %>">                           
                        </asp:TextBox>
                    </div>
                    <div>
                        <span>Web site:</span>
                        <asp:TextBox runat="server" ID="TextBoxWebSiteCreate" placeholder="Enter book web site ..." Text=" <%#: BindItem.WebSite %>">                           
                        </asp:TextBox>
                    </div>
                    <div>
                        <span>Description:</span>
                        <asp:TextBox runat="server" ID="TextBoxDescriptionCreate" placeholder="Enter book description ..." 
                            Text=" <%#: BindItem.Description %>" 
                            TextMode="MultiLine" Height="160">
                        </asp:TextBox>
                    </div>
                    <div>
                        <span>Category:</span>
                        <asp:DropDownList runat="server" ID="DropDownListCategoriesCreate" DataTextField="Name" DataValueField="ID" 
                            ItemType="Exam.WebForms.Models.Category" SelectedValue="<%#: BindItem.CategoryId %>" 
                            SelectMethod="DropDownListCategoriesCreate_GetData">
                        </asp:DropDownList>
                    </div>
                    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="link-button" Text="Create" CommandName="Insert"  />
                    <asp:LinkButton runat="server" ID="LinkButtonCancel" CssClass="link-button" Text="Cancel" CommandName="Cancel" PostBackUrl="~/Admin/EditBooks.aspx" />
                </InsertItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="back-link">
        <a href="/">Back to books</a>
    </div>

</asp:Content>
