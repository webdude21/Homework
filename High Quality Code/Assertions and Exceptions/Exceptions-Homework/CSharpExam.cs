namespace Exceptions
{
    using System;

    public class CSharpExam : Exam
    {
        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < 0 || this.Score > 100)
                {
                    throw new ArgumentException("The score should not be negative and should be greater than 100");
                }

                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}