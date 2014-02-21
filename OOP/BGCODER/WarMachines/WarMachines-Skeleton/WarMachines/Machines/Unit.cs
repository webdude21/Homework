namespace WarMachines.Machines
{
    public abstract class Unit
    {
        private string name;

        protected Unit(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
