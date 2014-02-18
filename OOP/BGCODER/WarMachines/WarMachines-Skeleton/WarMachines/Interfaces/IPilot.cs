namespace WarMachines.Interfaces
{
    public interface IPilot
    {
        string Name { get; set; }

        void AddMachine(IMachine machine);

        string Report();
    }
}
