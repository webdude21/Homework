using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank
    {
        public Tank(string name, double attackPoints, double defencePoints)
            : base(name, 100d, attackPoints, defencePoints) 
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !DefenseMode;
            if (DefenseMode)
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
