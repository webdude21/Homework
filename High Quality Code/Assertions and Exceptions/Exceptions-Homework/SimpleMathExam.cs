namespace Exceptions
{
    using System;

    public class SimpleMathExam : Exam
    {
        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }

            private set
            {
                if (value < 0 || value > 2)
                {
                    throw new ArgumentException("The valid range for count of the solved problems is between 0 and 2");
                }

                this.problemsSolved = value;
            }
        }

        public override ExamResult Check()
        {
            if (this.ProblemsSolved == 0)
            {
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            }

            if (this.problemsSolved == 1)
            {
                return new ExamResult(4, 2, 6, "Average result: nothing done.");
            }

            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }
    }
}