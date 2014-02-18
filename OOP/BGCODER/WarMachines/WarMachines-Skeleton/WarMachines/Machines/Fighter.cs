using WarMachines.Interfaces;

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
