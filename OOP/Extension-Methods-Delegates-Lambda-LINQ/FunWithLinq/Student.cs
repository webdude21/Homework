namespace FunWithLinq
{
    using System.Collections.Generic;

    internal class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Fn { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public List<int> Marks { get; set; }

        public int GroupNumber { get; set; }

        public Group Group { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Name: {0} {1}, FN: {2}, Tel: {3}, Email: {4}, GroupNumber: {5} Department: {6} Marks: {7}",
                    this.FirstName,
                    this.LastName,
                    this.Fn,
                    this.Tel,
                    this.Email,
                    this.GroupNumber,
                    this.Group.DepartmentName,
                    string.Join(",", this.Marks));
        }
    }
}