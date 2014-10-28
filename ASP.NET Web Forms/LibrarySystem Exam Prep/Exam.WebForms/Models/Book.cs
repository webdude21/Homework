﻿namespace Exam.WebForms.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public string WebSite { get; set; }

        public string Author { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}