using System;
using System.Collections.Generic;
using WarMachines.Interfaces;
using WarMachines.Machines;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace WarMachines.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WarMachines.Interfaces;

    public class Command : ICommand
    {
        private const char SplitCommandSymbol = ' ';

        private string name;
        private IList<string> parameters;

        private Command(string input)
        {
            this.TranslateInput(input);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of strings cannot be null.");
                }

                this.parameters = value;
            }
        }

        public static Command Parse(string input)
        {
            return new Command(input);
        }

        private void TranslateInput(string input)
        {
            var indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);

            this.Name = input.Substring(0, indexOfFirstSeparator);
            this.Parameters = input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

namespace WarMachines.Engine
{
    public class MachineFactory : IMachineFactory
    {
        private HashSet<string> usedNames = new HashSet<string>();

        private void CheckForDuplicateNames(string name)
        {
            if (usedNames.Contains(name))
            {
                throw new ArgumentException("Duplicates names are not allowed");
            }
        }

        public IPilot HirePilot(string name)
        {
            CheckForDuplicateNames(name);
            usedNames.Add(name);
            return new Pilot(name);
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            CheckForDuplicateNames(name);
            usedNames.Add(name);
            return new Tank(name, attackPoints, defensePoints);
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            CheckForDuplicateNames(name);
            usedNames.Add(name);
            return new Fighter(name, attackPoints, defensePoints, stealthMode);
        }
    }
}
namespace WarMachines.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using WarMachines.Interfaces;

    public sealed class WarMachineEngine : IWarMachineEngine
    {
        private const string InvalidCommand = "Invalid command name: {0}";
        private const string PilotHired = "Pilot {0} hired";
        private const string PilotExists = "Pilot {0} is hired already";
        private const string TankManufactured = "Tank {0} manufactured - attack: {1}; defense: {2}";
        private const string FighterManufactured = "Fighter {0} manufactured - attack: {1}; defense: {2}; stealth: {3}";
        private const string MachineExists = "Machine {0} is manufactured already";
        private const string MachineHasPilotAlready = "Machine {0} is already occupied";
        private const string PilotNotFound = "Pilot {0} could not be found";
        private const string MachineNotFound = "Machine {0} could not be found";
        private const string MachineEngaged = "Pilot {0} engaged machine {1}";
        private const string InvalidMachineOperation = "Machine {0} does not support this operation";
        private const string FighterOperationSuccessful = "Fighter {0} toggled stealth mode";
        private const string TankOperationSuccessful = "Tank {0} toggled defense mode";
        private const string InvalidAttackTarget = "Tank {0} cannot attack stealth fighter {1}";
        private const string AttackSuccessful = "Machine {0} was attacked by machine {1} - current health: {2}";

        private static readonly WarMachineEngine SingleInstance = new WarMachineEngine();

        private IMachineFactory factory;
        private IDictionary<string, IPilot> pilots;
        private IDictionary<string, IMachine> machines;

        private WarMachineEngine()
        {
            this.factory = new MachineFactory();
            this.pilots = new Dictionary<string, IPilot>();
            this.machines = new Dictionary<string, IMachine>();
        }

        public static WarMachineEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = Command.Parse(currentLine);
                commands.Add(currentCommand);

                currentLine = Console.ReadLine();
            }

            return commands;
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                string commandResult;

                switch (command.Name)
                {
                    case "HirePilot":
                        var pilotName = command.Parameters[0];
                        commandResult = this.HirePilot(pilotName);
                        reports.Add(commandResult);
                        break;

                    case "Report":
                        var pilotReporting = command.Parameters[0];
                        commandResult = this.PilotReport(pilotReporting);
                        reports.Add(commandResult);
                        break;

                    case "ManufactureTank":
                        var tankName = command.Parameters[0];
                        var tankAttackPoints = double.Parse(command.Parameters[1]);
                        var tankDefensePoints = double.Parse(command.Parameters[2]);
                        commandResult = this.ManufactureTank(tankName, tankAttackPoints, tankDefensePoints);
                        reports.Add(commandResult);
                        break;

                    case "DefenseMode":
                        var defenseModeTankName = command.Parameters[0];
                        commandResult = this.ToggleTankDefenseMode(defenseModeTankName);
                        reports.Add(commandResult);
                        break;

                    case "ManufactureFighter":
                        var fighterName = command.Parameters[0];
                        var fighterAttackPoints = double.Parse(command.Parameters[1]);
                        var fighterDefensePoints = double.Parse(command.Parameters[2]);
                        var fighterStealthMode = command.Parameters[3] == "StealthON" ? true : false;
                        commandResult = this.ManufactureFighter(fighterName, fighterAttackPoints, fighterDefensePoints, fighterStealthMode);
                        reports.Add(commandResult);
                        break;

                    case "StealthMode":
                        var stealthModeFighterName = command.Parameters[0];
                        commandResult = this.ToggleFighterStealthMode(stealthModeFighterName);
                        reports.Add(commandResult);
                        break;

                    case "Engage":
                        var selectedPilotName = command.Parameters[0];
                        var selectedMachineName = command.Parameters[1];
                        commandResult = this.EngageMachine(selectedPilotName, selectedMachineName);
                        reports.Add(commandResult);
                        break;

                    case "Attack":
                        var attackingMachine = command.Parameters[0];
                        var defendingMachine = command.Parameters[1];
                        commandResult = this.AttackMachines(attackingMachine, defendingMachine);
                        reports.Add(commandResult);
                        break;

                    default:
                        reports.Add(string.Format(InvalidCommand, command.Name));
                        break;
                }
            }

            return reports;
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
            }

            Console.Write(output.ToString());
        }

        private string HirePilot(string name)
        {
            if (this.pilots.ContainsKey(name))
            {
                return string.Format(PilotExists, name);
            }

            var pilot = this.factory.HirePilot(name);
            this.pilots.Add(name, pilot);

            return string.Format(PilotHired, name);
        }

        private string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.ContainsKey(name))
            {
                return string.Format(MachineExists, name);
            }

            var tank = this.factory.ManufactureTank(name, attackPoints, defensePoints);
            this.machines.Add(name, tank);

            return string.Format(TankManufactured, name, attackPoints, defensePoints);
        }

        private string ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            if (this.machines.ContainsKey(name))
            {
                return string.Format(MachineExists, name);
            }

            var fighter = this.factory.ManufactureFighter(name, attackPoints, defensePoints, stealthMode);
            this.machines.Add(name, fighter);

            return string.Format(FighterManufactured, name, attackPoints, defensePoints, stealthMode == true ? "ON" : "OFF");
        }

        private string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!this.pilots.ContainsKey(selectedPilotName))
            {
                return string.Format(PilotNotFound, selectedPilotName);
            }

            if (!this.machines.ContainsKey(selectedMachineName))
            {
                return string.Format(MachineNotFound, selectedMachineName);
            }

            if (this.machines[selectedMachineName].Pilot != null)
            {
                return string.Format(MachineHasPilotAlready, selectedMachineName);
            }

            var pilot = this.pilots[selectedPilotName];
            var machine = this.machines[selectedMachineName];

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return string.Format(MachineEngaged, selectedPilotName, selectedMachineName);
        }

        private string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!this.machines.ContainsKey(attackingMachineName))
            {
                return string.Format(MachineNotFound, attackingMachineName);
            }

            if (!this.machines.ContainsKey(defendingMachineName))
            {
                return string.Format(MachineNotFound, defendingMachineName);
            }

            var attackingMachine = this.machines[attackingMachineName];
            var defendingMachine = this.machines[defendingMachineName];

            if (attackingMachine is ITank && defendingMachine is IFighter && (defendingMachine as IFighter).StealthMode)
            {
                return string.Format(InvalidAttackTarget, attackingMachineName, defendingMachineName);
            }

            attackingMachine.Targets.Add(defendingMachineName);

            var attackPoints = attackingMachine.AttackPoints;
            var defensePoints = defendingMachine.DefensePoints;

            var damage = attackPoints - defensePoints;

            if (damage > 0)
            {
                var newHeathPoints = defendingMachine.HealthPoints - damage;

                if (newHeathPoints < 0)
                {
                    newHeathPoints = 0;
                }

                defendingMachine.HealthPoints = newHeathPoints;
            }

            return string.Format(AttackSuccessful, defendingMachineName, attackingMachineName, defendingMachine.HealthPoints);
        }

        private string PilotReport(string pilotReporting)
        {
            if (!this.pilots.ContainsKey(pilotReporting))
            {
                return string.Format(PilotNotFound, pilotReporting);
            }

            return this.pilots[pilotReporting].Report();
        }

        private string ToggleFighterStealthMode(string stealthModeFighterName)
        {
            if (!this.machines.ContainsKey(stealthModeFighterName))
            {
                return string.Format(MachineNotFound, stealthModeFighterName);
            }

            if (this.machines[stealthModeFighterName] is ITank)
            {
                return string.Format(InvalidMachineOperation, stealthModeFighterName);
            }

            var machineAsFighter = this.machines[stealthModeFighterName] as IFighter;
            machineAsFighter.ToggleStealthMode();

            return string.Format(FighterOperationSuccessful, stealthModeFighterName);
        }

        private string ToggleTankDefenseMode(string defenseModeTankName)
        {
            if (!this.machines.ContainsKey(defenseModeTankName))
            {
                return string.Format(MachineNotFound, defenseModeTankName);
            }

            if (this.machines[defenseModeTankName] is IFighter)
            {
                return string.Format(InvalidMachineOperation, defenseModeTankName);
            }

            var machineAsFighter = this.machines[defenseModeTankName] as ITank;
            machineAsFighter.ToggleDefenseMode();

            return string.Format(TankOperationSuccessful, defenseModeTankName);
        }
    }
}
namespace WarMachines.Interfaces
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}
namespace WarMachines.Interfaces
{
    public interface IFighter : IMachine
    {
        bool StealthMode { get; }

        void ToggleStealthMode();
    }
}
namespace WarMachines.Interfaces
{
    using System.Collections.Generic;

    public interface IMachine
    {
        string Name { get; set; }

        IPilot Pilot { get; set; }

        double HealthPoints { get; set; }

        double AttackPoints { get; }

        double DefensePoints { get; }

        IList<string> Targets { get; }

        void Attack(string target);

        string ToString();
    }
}
namespace WarMachines.Interfaces
{
    public interface IMachineFactory
    {
        IPilot HirePilot(string name);

        ITank ManufactureTank(string name, double attackPoints, double defensePoints);

        IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode);
    }
}
namespace WarMachines.Interfaces
{
    public interface IPilot
    {
        string Name { get; set; }

        void AddMachine(IMachine machine);

        string Report();
    }
}
namespace WarMachines.Interfaces
{
    public interface ITank : IMachine
    {
        bool DefenseMode { get; }

        void ToggleDefenseMode();
    }
}
namespace WarMachines.Interfaces
{
    using System.Collections.Generic;

    public interface IWarMachineEngine
    {
        void Start();
    }
}

namespace WarMachines.Machines
{
    class Fighter : Machine, IFighter
    {
        bool stealthMode;

        public Fighter(string name, double attackPoints, double defencePoints, bool stealthMode)
            : base(name, 200d, attackPoints, defencePoints) 
        {
            this.stealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
        }

        public void ToggleStealthMode()
        {
            this.stealthMode = !stealthMode;
        }

        public override string ToString()
        {
            return base.ToString() + " *Stealth: " + (this.StealthMode ? "ON" : "OFF");
        }
    }
}

namespace WarMachines.Machines
{
     public abstract class Machine : Unit, IMachine
    {
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets = new List<string>();

        public Machine(string name, double healthPoints, double attackPoints, double defensePoints)
            : base(name) 
        {
            this.healthPoints = healthPoints;
            this.attackPoints = attackPoints;
            this.defensePoints = defensePoints;
        }

        private bool CheckIfNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("This property cannot be null!");
            }
            return false;
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (!CheckIfNull(value))
                {
                    this.pilot = value;
                }   
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
            protected set
            {
                if (!CheckIfNull(value))
                {
                    this.attackPoints = value;
                }               
            }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
            protected set
            {
                if (!CheckIfNull(value))
                {
                    this.defensePoints = value;
                }             
            }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
        }

        public void Attack(string target)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder machineString = new StringBuilder();

            string targets = null;
            if (this.targets.Count != 0)
            {
                targets = string.Join(", ", this.targets);
            }
            
            machineString.Append(" *Type: " + GetType().Name);
            machineString.Append(System.Environment.NewLine);
            machineString.Append(" *Health: " + this.healthPoints);
            machineString.Append(System.Environment.NewLine);
            machineString.Append(" *Attack: " + this.attackPoints);
            machineString.Append(System.Environment.NewLine);
            machineString.Append(" *Defense: " + this.defensePoints);
            machineString.Append(System.Environment.NewLine);
            machineString.Append(" *Targets: " + (targets ?? "None"));
            machineString.Append(System.Environment.NewLine);
            return machineString.ToString();
        }
    }
}

namespace WarMachines.Machines
{
    
    public class Pilot : Unit, IPilot
    {
        private HashSet<IMachine> machines = new HashSet<IMachine>();

        public Pilot(string name) : base(name) { }
        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder pilotReport = new StringBuilder();

            if (this.machines.Count == 1)
            {
                pilotReport.Append(" - 1 machine");
                pilotReport.Append(System.Environment.NewLine);
            }
            else if (this.machines.Count > 1)
            {
                pilotReport.Append(" - " + this.machines.Count + " machines");
                pilotReport.Append(System.Environment.NewLine);
            }
            else
            {
                pilotReport.Append(" - no machines");
            }

            foreach (var machine in machines.OrderBy(machine => machine.HealthPoints).ThenBy(machine => machine.Name))
            {
                pilotReport.Append("- ");
                pilotReport.Append(machine.Name);
                pilotReport.Append(System.Environment.NewLine);
                pilotReport.Append(machine.ToString());
            }

            return base.ToString() + pilotReport.ToString().TrimEnd();
        }
    }
}

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank
    {
        bool defenceMode;

        public Tank(string name, double attackPoints, double defencePoints)
            : base(name, 100d, attackPoints, defencePoints) 
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode
        {
            get { return this.defenceMode; }
        }

        public void ToggleDefenseMode()
        {
            this.defenceMode = !defenceMode;
            if (defenceMode)
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
            else
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " *Defense: " + (this.DefenseMode ? "ON" : "OFF" ) + System.Environment.NewLine;
        }
    }
}

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
namespace WarMachines
{
    using WarMachines.Engine;

    public class WarMachinesProgram
    {
        public static void Main()
        {
            WarMachineEngine.Instance.Start();
        }
    }
}
