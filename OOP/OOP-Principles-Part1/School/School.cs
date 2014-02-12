using System.Collections.Generic;

namespace School
{
    public class School
    {
        private List<Class> classes = new List<Class>();
        private string name;

        public School(string schoolName)
        {
            this.name = schoolName;
        }

        // I've made left the option to rename the school public, because schools often get renamed
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

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
            return this.name.ToString();
        }
    }
}
