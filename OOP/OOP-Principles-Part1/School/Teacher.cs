namespace School
{
    using System.Collections.Generic;

    public class Teacher : Person, ICommentable
    {
        private readonly List<Discipline> toughtDisciplines = new List<Discipline>();

        public Teacher(string teacherName)
        {
            this.name = teacherName;
        }

        public string Comments { get; set; }

        public void AddToughtDisciplines(params Discipline[] disciplines)
        {
            foreach (var disc in disciplines)
            {
                this.toughtDisciplines.Add(disc);
            }
        }

        public void RemoveToughtDisciplines(params Discipline[] disciplines)
        {
            foreach (var disc in disciplines)
            {
                this.toughtDisciplines.Remove(disc);
            }
        }

        public void RemoveAllToughtDisciplines()
        {
            this.toughtDisciplines.Clear();
        }

        public override string ToString()
        {
            return string.Format("Аз съм {0} и съм учител.", this.name);
        }
    }
}