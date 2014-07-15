namespace School
{
    public class Discipline : ICommentable
    {
        public Discipline(string disciplineName, int numOfLectures, int numOfExercises)
        {
            this.Name = disciplineName;
            this.NumberOfExercises = numOfExercises;
            this.NumberOfLectures = numOfLectures;
        }

        public int NumberOfExercises { get; set; }

        public string Name { get; set; }

        public int NumberOfLectures { get; set; }

        public string Comments { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Предметът {0} има {1} лекции и {2} упражнения.", 
                this.Name, 
                this.NumberOfLectures, 
                this.NumberOfExercises);
        }
    }
}