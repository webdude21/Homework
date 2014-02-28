using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IGatherer, IFighter
    {
        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints = 250;
                return true;
            }

            return false;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints
        {
            get { return 80; }

        }
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
