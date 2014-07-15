namespace School
{
    using System.Collections.Generic;

    public class School
    {
        private readonly List<Class> classes = new List<Class>();

        public School(string schoolName)
        {
            this.Name = schoolName;
        }

        public string Name { get; set; }

        public void AddClass(Class newClass)
        {
            this.classes.Add(newClass);
        }

        public void RemoveClass(Class classToRemove)
        {
            this.classes.Remove(classToRemove);
        }

        public void RemoveAllClasses()
        {
            this.classes.Clear();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
