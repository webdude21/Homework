namespace StudentRegistration
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonSubmitClick(object sender, EventArgs e)
        {
            var panel = new Panel();
            panel.ID = "PanelResult";

            var heading = new HtmlGenericControl("h1") { InnerText = "Student Info" };

            var paragraph = new HtmlGenericControl("p")
                                {
                                    InnerHtml =
                                        string.Format(
                                            @"<strong>First Name: </strong>{0}<br />
                  <strong>Last Name: </strong>{1}<br />
                  <strong>Faculty Number: </strong>{2}<br />
                  <strong>University: </strong>{3}<br />
                  <strong>Specialty: </strong>{4}<br />
                  <strong>Courses:</strong><br />", 
                                            this.TextBoxFirstName.Text, 
                                            this.TextBoxLastName.Text, 
                                            this.TextBoxFacultyNumber.Text, 
                                            this.DropDownListUniversity.SelectedItem.Text, 
                                            this.DropDownListSpeciality.SelectedItem.Text)
                                };

            foreach (var item in this.ListBoxCourses.GetSelectedIndices().Select(index => this.ListBoxCourses.Items[index].Text))
            {
                paragraph.InnerHtml += item + "<br />";
            }

            panel.Controls.Add(heading);
            panel.Controls.Add(paragraph);
            this.Controls.Add(panel);
        }
    }
}