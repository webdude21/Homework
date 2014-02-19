namespace WarMachines.Machines
{
    public abstract class Unit
    {
        string name;

        public Unit(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
