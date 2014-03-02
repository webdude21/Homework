using System.Collections.Generic;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLElement : IElement
    {
        private IList<IElement> childElements;
        public HTMLElement(string name, string textContent = null)
        {
            this.Name = name;

            if (textContent != null)
            {
                this.TextContent = textContent;
            }

            this.childElements = new List<IElement>();
        }
        public string Name { get; protected set; }

        public virtual string TextContent { get; set; }

        public virtual IEnumerable<IElement> ChildElements
        {
            get { return new List<IElement>(childElements); }
        }

        public virtual void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.AppendFormat("<{0}>", this.Name);
            }

            if (this.TextContent != null)
            {
                EscapeSpecialCharacters(output);
            }

            foreach (var child in childElements)
            {
                child.Render(output);
            }

            if (this.Name != null)
            {
                output.AppendFormat("</{0}>", this.Name);
            }
        }

        private void EscapeSpecialCharacters(StringBuilder output)
        {
            string escapedChars = this.TextContent;
            escapedChars = escapedChars.Replace("&", "&amp;");
            escapedChars = escapedChars.Replace("<", "&lt;");
            escapedChars = escapedChars.Replace(">", "&gt;");
            output.Append(escapedChars);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            this.Render(output);
            return output.ToString();
        }
    }
}
