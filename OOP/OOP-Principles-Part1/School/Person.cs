namespace School
{
    public abstract class Person
    {
        protected Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}