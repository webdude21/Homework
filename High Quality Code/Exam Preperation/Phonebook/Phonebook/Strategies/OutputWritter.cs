namespace Phonebook.Strategies
{
    using System.Text;

    using Phonebook.Contracts;

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