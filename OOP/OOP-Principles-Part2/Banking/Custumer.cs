namespace Banking
{
    public abstract class Custumer
    {
        protected Custumer(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}