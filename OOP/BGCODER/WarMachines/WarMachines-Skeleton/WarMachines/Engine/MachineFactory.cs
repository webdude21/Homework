using System;
using System.Collections.Generic;
using WarMachines.Interfaces;
using WarMachines.Machines;

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
