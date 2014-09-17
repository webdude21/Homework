namespace StudentSystem.Model
{
    using System;

    public class Homework
    {
        public int Id { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }

        public string FilePath { get; set; }

        public DateTime SentDateTime { get; set; }
    }
}