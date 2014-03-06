using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {
        public string Name { get; set; }
        public string Content { get; set; }


        public void LoadProperty(string key, string value)
        {
            foreach (var property in this.GetType().GetProperties().Where(property => property.Name.ToLowerInvariant() == key))
            {
                property.SetValue(this, value);
                return;
            }
        }
        public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            foreach (var property in this.GetType().GetProperties())
            {
                output.Add(new KeyValuePair<string, object>(property.Name.ToLowerInvariant(), property));
            }
        }

        public override string ToString()
        {
            var properties = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(properties);
            properties.Sort((a, b) => a.Key.CompareTo(b.Key));
            var result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append("[");
            bool first = true;
            foreach (var prop in properties)
            {
                if (prop.Value != null)
                {
                    if (!first)
                    {
                        result.Append(";");
                    }
                    result.AppendFormat("{0}={1}", prop.Key, prop.Value);
                    first = false;
                }
            }
            result.Append("]");
            return result.ToString();
        }
    }
}
