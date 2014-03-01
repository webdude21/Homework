using System.Collections.Generic;
using System.Linq;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        public Ninja(string name, Point position, int owner) : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.DefensePoints = int.MaxValue;
        }

        public int AttackPoints { get; private set; }
        public int DefensePoints { get; private set; }
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0
                    && availableTargets.Max(target => target.HitPoints == availableTargets[i].HitPoints))
                {
                    return i;
                }
            }

            return -1;
        }
        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints = this.AttackPoints + resource.Quantity;
                return true;
            }
            if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints = this.AttackPoints + (resource.Quantity * 2);
                return true;
            }
            return false;
        }
    }
}
