namespace School
{
    public class Discipline : ICommentable
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;

        public Discipline(string disciplineName, int numOfLectures, int numOfExercises)
        {
            this.Name = disciplineName;
            this.NumberOfExercises = numOfExercises;
            this.NumberOfLectures = numOfLectures;
        }

        public int NumberOfExercises
        {
            get { return numberOfExercises; }
            set { numberOfExercises = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NumberOfLectures
        {
            get { return numberOfLectures; }
            set { numberOfLectures = value; }
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
            return string.Format("Предметът {0} има {1} лекции и {2} упражнения.", this.name, this.numberOfLectures, this.numberOfExercises);
        }
    }
}
