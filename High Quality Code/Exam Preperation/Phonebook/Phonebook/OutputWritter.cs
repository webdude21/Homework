namespace Phonebook
{
    using System.Text;

    using Phonebook.Contracts;

    /// <summary>
    /// Strategy Pattern
    /// </summary>
    public class OutputWritter : IOutputWritter
    {
        private readonly StringBuilder stringBuilder;

        public OutputWritter(StringBuilder stringBuilder)
        {
            this.stringBuilder = stringBuilder;
        }

        public OutputWritter()
        {
            this.stringBuilder = new StringBuilder();
        }

        public int Length
        {
            get
            {
                return this.stringBuilder.Length;
            }
        }

        public void WriteOutput(string text)
        {
            this.stringBuilder.AppendLine(text);
        }

        public override string ToString()
        {
            return this.stringBuilder.ToString();
        }
    }
}