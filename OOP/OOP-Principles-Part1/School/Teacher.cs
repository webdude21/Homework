using System.Collections.Generic;

namespace School
{
    public class Teacher : Person, ICommentable
    {
        private List<Discipline> toughtDisciplines = new List<Discipline>();

        public Teacher(string teacherName)
        {
            this.name = teacherName;
        }

        public void AddToughtDisciplines(params Discipline[] disciplines)
        {
            foreach (Discipline disc in disciplines)
            {
                this.toughtDisciplines.Add(disc);
            }
        }

        public void RemoveToughtDisciplines(params Discipline[] disciplines)
        {
            foreach (Discipline disc in disciplines)
            {
                this.toughtDisciplines.Remove(disc);
            }
        }

        public void RemoveAllToughtDisciplines()
        {
            this.toughtDisciplines.Clear();
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
            return string.Format("Аз съм {0} и съм учител.", this.name);
        }
    }
}