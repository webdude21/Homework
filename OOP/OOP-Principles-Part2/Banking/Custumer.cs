namespace Banking
{
    public abstract class Custumer
    {
        public Custumer(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}