using System;
using System.Collections.Generic;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLTable : HTMLElement, ITable
    {
        private const string TableName = "table";
        private const string TableRowOpenTag = "<tr>";
        private const string TableRowCloseTag = "</tr>";
        private const string TableColumnOpenTag = "<td>";
        private const string TableColumnCloseTag = "</td>";

        private readonly IElement[,] tableContent;
        public HTMLTable(int rows, int cols)
            : base(TableName)
        {
            this.tableContent = new IElement[rows, cols];
        }

        public int Rows
        {
            get { return this.tableContent.GetLength(0); }
        }

        public int Cols
        {
            get { return this.tableContent.GetLength(1); }
        }

        public override string TextContent
        {
            get
            {
                throw new InvalidOperationException("The HTML table doesn't have Text Content");
            }

            set
            {
                throw new InvalidOperationException("The HTML table doesn't have Text Content");
            }
        }

        public IElement this[int row, int col]
        {
            get
            {
                this.CheckIfIndexIsValid(row, col);
                return this.tableContent[row, col];
            }
            set
            {
                this.CheckIfIndexIsValid(row, col);
                this.tableContent[row, col] = value;
            }
        }

        public override IEnumerable<IElement> ChildElements
        {

            get { throw new InvalidOperationException("The table doesn't have child elements"); }
        }

        public override void AddElement(IElement element)
        {
            throw new InvalidOperationException("The table doesn't have child elements");
        }

        private void CheckIfIndexIsValid(int row, int col)
        {
            if ((row >= this.Rows || row < 0) || (col >= this.Cols || col < 0))
            {
                throw new IndexOutOfRangeException("The table doesn't have such index.");
            }
        }

        public override void Render(StringBuilder output)
        {
            output.AppendFormat("<{0}>", this.Name);

            for (int row = 0; row < this.Rows; row++)
            {
                output.Append(TableRowOpenTag);
                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append(TableColumnOpenTag);
                    output.Append(this.tableContent[row, col].ToString());
                    output.Append(TableColumnCloseTag);
                }
                output.Append(TableRowCloseTag);
            }
            output.AppendFormat("</{0}>", this.Name);
        }
    }
}
