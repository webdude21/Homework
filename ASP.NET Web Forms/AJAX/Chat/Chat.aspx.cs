namespace Chat
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Web.UI;

    using ChatData;

    public partial class Chat : Page
    {
        public Chat()
        {
            this.ChtaDbContext = new ChatDbContext();
        }

        public ChatDbContext ChtaDbContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable ListViewChat_Select()
        {
            this.ChtaDbContext.Messages.OrderBy()
        }
    }
}