using System;
using System.Collections.Generic;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
     public abstract class Machine : Unit, IMachine
    {
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private readonly IList<string> targets = new List<string>();

         protected Machine(string name, double healthPoints, double attackPoints, double defensePoints)
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
                throw new NullReferenceException("This property cannot be null!");
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
            CheckIfNull(target);
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
            
            machineString.Append(" *Type: " + GetType().Name);
            machineString.Append(Environment.NewLine);
            machineString.Append(" *Health: " + this.healthPoints);
            machineString.Append(Environment.NewLine);
            machineString.Append(" *Attack: " + this.attackPoints);
            machineString.Append(Environment.NewLine);
            machineString.Append(" *Defense: " + this.defensePoints);
            machineString.Append(Environment.NewLine);
            machineString.Append(" *Targets: " + (targetString ?? "None"));
            machineString.Append(Environment.NewLine);
            return machineString.ToString();
        }
    }
}
