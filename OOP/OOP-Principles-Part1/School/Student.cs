namespace School
{
    public class Student : Person, ICommentable
    {
        private int uniqueClassNumber;

        public Student(string studentName, int studentNumber)
        {
            this.name = studentName;
            this.uniqueClassNumber = studentNumber;
        }

        public int UniqueClassNumber
        {
            get { return uniqueClassNumber; }
            set { uniqueClassNumber = value; }
        }

        public string Comments
        {
            get
            {
                return this.Comments;
            }
            set
            {
                this.Comments = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Аз съм {0} и моят номер е {1}", this.name, this.uniqueClassNumber);
        }
    }
}
