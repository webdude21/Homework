namespace WarMachines.Machines
{
    public abstract class Unit
    {
        protected Unit(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
