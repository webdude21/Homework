namespace School
{
    public class Student : Person, ICommentable
    {
        public Student(string studentName, int studentNumber)
        {
            this.name = studentName;
            this.UniqueClassNumber = studentNumber;
        }

        public int UniqueClassNumber { get; set; }

        public string Comments { get; set; }

        public override string ToString()
        {
            return string.Format("Аз съм {0} и моят номер е {1}", this.name, this.UniqueClassNumber);
        }
    }
}