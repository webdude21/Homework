<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="Chat.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chat</title>
</head>
<body>
    <form id="formChat" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div>
            <div>
                <asp:Label runat="server" AssociatedControlID="TextBoxAuthor" ID="UsernameLabel" Text="Author: " />
                <asp:TextBox runat="server" ID="TextBoxAuthor" Text='<%#Bind("Author") %>'></asp:TextBox>

                <asp:Label runat="server" AssociatedControlID="TextBoxBody" ID="MessageLabel" Text="Message: " />
                <asp:TextBox runat="server" ID="TextBoxBody" Text='<%#Bind("Body") %>'></asp:TextBox>
                <asp:LinkButton ID="InsertButton" runat="server"
                    CommandName="Insert" Text="Send" OnCommand="InsertButton_Command" />
            </div>
            <asp:ListView runat="server" ID="ListViewChat" 
                InsertItemPosition="FirstItem" DataKeyNames="Id" OnItemInserting="ChatListView_ItemInserting"
                ItemType="ChatData.Models.Message">
                <LayoutTemplate>
                    <asp:UpdatePanel ID="AjaxChatUpdatePanel" runat="server">
                        <Triggers>
                            <asp:AsyncPostBackTrigger EventName="Tick" ControlID="TimerChatRefresh" />
                        </Triggers>
                        <ContentTemplate>
                            <div id="itemPlaceHolder" runat="server"></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </LayoutTemplate>
                <ItemTemplate>
                    <div>
                        <b><%#: Item.Author %>: </b>
                        <i><%#: Item.Body %></i>
                    </div>
                </ItemTemplate>
                <InsertItemTemplate>
                </InsertItemTemplate>
            </asp:ListView>

            <asp:Timer ID="TimerChatRefresh" runat="server" Interval="500" />
        </div>
    </form>
</body>
</html>
