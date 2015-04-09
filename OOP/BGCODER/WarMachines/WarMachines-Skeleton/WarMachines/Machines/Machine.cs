namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using WarMachines.Interfaces;

    public abstract class Machine : Unit, IMachine
    {
        private readonly IList<string> targets = new List<string>();

        private double attackPoints;

        private double defensePoints;

        private IPilot pilot;

        protected Machine(string name, double healthPoints, double attackPoints, double defensePoints) : base(name)
        {
            this.HealthPoints = healthPoints;
            this.attackPoints = attackPoints;
            this.defensePoints = defensePoints;
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (!this.CheckIfNull(value))
                {
                    this.pilot = value;
                }
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            protected set
            {
                if (!this.CheckIfNull(value))
                {
                    this.attackPoints = value;
                }
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
            protected set
            {
                if (!this.CheckIfNull(value))
                {
                    this.defensePoints = value;
                }
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }
        }

        public void Attack(string target)
        {
            this.CheckIfNull(target);
            this.targets.Add(target);
        }

        public override string ToString()
        {
            var machineString = new StringBuilder();

            string targetString = null;
            if (this.targets.Count != 0)
            {
                targetString = string.Join(", ", this.targets);
            }

            machineString.Append(" *Type: " + this.GetType().Name);
            machineString.Append(Environment.NewLine);
            machineString.Append(" *Health: " + this.HealthPoints);
            machineString.Append(Environment.NewLine);
            machineString.Append(" *Attack: " + this.attackPoints);
            machineString.Append(Environment.NewLine);
            machineString.Append(" *Defense: " + this.defensePoints);
            machineString.Append(Environment.NewLine);
            machineString.Append(" *Targets: " + (targetString ?? "None"));
            machineString.Append(Environment.NewLine);
            return machineString.ToString();
        }

        private bool CheckIfNull(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException("This property cannot be null!");
            }
            return false;
        }
    }
}