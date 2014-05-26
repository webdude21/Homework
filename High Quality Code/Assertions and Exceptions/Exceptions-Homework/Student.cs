namespace Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private IList<Exam> exams;

        private string firstName;

        private string lastName;

        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The first name cannot be null or empty");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The last name cannot be null or empty");
                }

                this.lastName = value;
            }
        }

        public IList<Exam> Exams
        {
            get
            {
                return this.exams;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Exams", "List cannot be null");
                }

                this.exams = value;
            }
        }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams == null || this.Exams.Count == 0)
            {
                return new List<ExamResult>();
            }

            return this.Exams.Select(exam => exam.Check()).ToList();
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams.Count == 0)
            {
                throw new InvalidOperationException("There are no exams");
            }

            var examScore = new double[this.Exams.Count];
            var examResults = this.CheckExams();
            for (var i = 0; i < examResults.Count; i++)
            {
                examScore[i] = ((double)examResults[i].Grade - examResults[i].MinGrade)
                               / (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}