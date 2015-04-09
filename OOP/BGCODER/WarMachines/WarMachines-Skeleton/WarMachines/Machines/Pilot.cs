namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using WarMachines.Interfaces;

    public class Pilot : Unit, IPilot
    {
        private readonly HashSet<IMachine> machines = new HashSet<IMachine>();

        public Pilot(string name)
            : base(name)
        {
        }

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            var pilotReport = new StringBuilder();

            if (this.machines.Count == 1)
            {
                pilotReport.AppendLine(" - 1 machine");
            }
            else if (this.machines.Count > 1)
            {
                pilotReport.AppendLine(" - " + this.machines.Count + " machines");
            }
            else
            {
                pilotReport.Append(" - no machines");
            }

            foreach (var machine in this.machines.OrderBy(machine => machine.HealthPoints).ThenBy(machine => machine.Name))
            {
                pilotReport.Append("- ");
                pilotReport.AppendLine(machine.Name);
                pilotReport.Append(machine.ToString());
            }

            return this + pilotReport.ToString().TrimEnd();
        }
    }
}