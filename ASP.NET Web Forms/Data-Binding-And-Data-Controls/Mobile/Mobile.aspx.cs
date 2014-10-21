namespace Mobile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    using global::Mobile.Models;

    public partial class Mobile : Page
    {
        public ICollection<Producer> Producers
        {
            get
            {
                return new[]
                           {
                               new Producer
                                   {
                                       Name = "BMW", 
                                       Models =
                                           new[]
                                               {
                                                   new Model { Name = "1" }, new Model { Name = "3" }, 
                                                   new Model { Name = "4" }, new Model { Name = "6" }, 
                                                   new Model { Name = "5" }, new Model { Name = "7" }, 
                                                   new Model { Name = "X3" }, new Model { Name = "X6" }, 
                                                   new Model { Name = "M5" }, new Model { Name = "M6" }
                                               }
                                   }, 
                               new Producer
                                   {
                                       Name = "Audi", 
                                       Models =
                                           new[]
                                               {
                                                   new Model { Name = "A2" }, new Model { Name = "A3" }, 
                                                   new Model { Name = "A4" }, new Model { Name = "A6" }, 
                                                   new Model { Name = "A5" }, new Model { Name = "A8" }, 
                                                   new Model { Name = "Q7" }, new Model { Name = "Q5" }
                                               }
                                   }, 
                               new Producer
                                   {
                                       Name = "Ford", 
                                       Models =
                                           new[]
                                               {
                                                   new Model { Name = "Fiesta" }, new Model { Name = "Orion" }, 
                                                   new Model { Name = "Focus" }, new Model { Name = "Galaxy" }, 
                                                   new Model { Name = "Mondeo" }, new Model { Name = "Sierra" }, 
                                                   new Model { Name = "Scorpio" }, new Model { Name = "Escort" }
                                               }
                                   }
                           };
            }
        }

        public ICollection<Extra> Extras
        {
            get
            {
                return new[]
                           {
                               new Extra { Name = "Climate Control" }, new Extra { Name = "Air Con" }, 
                               new Extra { Name = "ABS" }, new Extra { Name = "Electric Windows" }, 
                               new Extra { Name = "Electric mirrors" }, new Extra { Name = "Power assisted steering" }, 
                               new Extra { Name = "Leather Upholstery" }, new Extra { Name = "Heated Seats" }, 
                               new Extra { Name = "Heated Windshield" }, new Extra { Name = "Xenon Headlights" }, 
                               new Extra { Name = "Radio" }, new Extra { Name = "CD/MP3" }
                           };
            }
        }

        public ICollection<string> Engines
        {
            get
            {
                return new[] { "Gasoline", "Diesel", "LPG", "CNG", "Electric", "Hybrid" };
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.DropDownListProducer.DataSource = this.Producers;
                this.DropDownListProducer.DataBind();
                this.RadioButtonListEngines.DataSource = this.Engines;
                this.CheckBoxListExtras.DataSource = this.Extras;
                this.SelectModels();
                this.DataBind();
            }
        }

        protected void ProducersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectModels();
        }

        protected void SelectModels()
        {
            var selectedProducer = this.Producers.FirstOrDefault(p => p.Name == this.DropDownListProducer.SelectedValue);
            if (selectedProducer != null)
            {
                this.DropDownModels.DataSource = selectedProducer.Models;
                this.DataBind();
            }
        }

        protected void FormSubmiter_Click(object sender, EventArgs e)
        {
            var html = new HtmlGenericControl("div");
            var breakLine = "<br/>";
            html.InnerHtml += this.DropDownListProducer.SelectedValue + breakLine;
            html.InnerHtml += this.DropDownModels.SelectedValue + breakLine;

            foreach (var item in this.CheckBoxListExtras.Items.Cast<ListItem>().Where(item => item.Selected))
            {
                html.InnerHtml += item + breakLine;
            }

            html.InnerHtml += this.RadioButtonListEngines.SelectedValue + breakLine;

            this.LiteralResult.Text = html.InnerText;
        }
    }
}