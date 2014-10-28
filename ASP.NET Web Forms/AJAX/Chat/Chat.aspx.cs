namespace Chat
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using ChatData;
    using ChatData.Models;

    public partial class Chat : Page
    {
        public Chat()
        {
            this.ChatDbContext = new ChatDbContext();
        }

        public ChatDbContext ChatDbContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.ViewState["author"] != null)
            {
                this.TextBoxAuthor.Text = (string)this.ViewState["author"];
            }

            this.TextBoxBody.Text = string.Empty;

            this.ListViewChat.DataSource = this.ChatDbContext.Messages.OrderByDescending(message => message.CreatedDate).Take(100).ToList();
            this.ListViewChat.DataBind();
        }

        protected void InsertButton_Command(object sender, CommandEventArgs e)
        {
            var author = this.TextBoxAuthor.Text;
            if (string.IsNullOrWhiteSpace(author))
            {
                return;
            }


            this.ViewState["author"] = author;

            var body = this.TextBoxBody.Text;

            if (string.IsNullOrWhiteSpace(body))
            {
                return;
            }


            this.ChatDbContext.Messages.Add(new Message { Author = author, Body = body });

            this.ChatDbContext.SaveChanges();
        }

        protected void ChatListView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {

        }
    }
}