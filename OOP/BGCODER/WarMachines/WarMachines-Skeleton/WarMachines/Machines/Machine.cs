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
