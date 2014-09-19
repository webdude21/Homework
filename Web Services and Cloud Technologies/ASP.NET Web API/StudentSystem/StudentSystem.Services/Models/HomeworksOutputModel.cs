namespace StudentSystem.Services.Models
{
    using System;
    using System.Linq.Expressions;

    using StudentSystem.Model;

    public class HomeworksOutputModel
    {
        public static Expression<Func<Homework, HomeworksOutputModel>> FromHomework
        {
            get
            {
                return hm => new HomeworksOutputModel
                                {
                                    FilePath = hm.FilePath,
                                    Id = hm.Id,
                                    SentDateTime = hm.SentDateTime
                                };
            }
        }

        public int Id { get; set; }

        public string FilePath { get; set; }

        public DateTime SentDateTime { get; set; }
    }
}