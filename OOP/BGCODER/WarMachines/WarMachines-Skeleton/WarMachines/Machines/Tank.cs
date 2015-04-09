namespace WarMachines.Machines
{
    using System;

    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, 100d, attackPoints, defensePoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
            if (this.DefenseMode)
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
            return base.ToString() + " *Defense: " + (this.DefenseMode ? "ON" : "OFF") + Environment.NewLine;
        }
    }
}