using System.Collections.Generic;

namespace AcademyRPG
{
    public class Knight : Character, IFighter
    {
        private const int AtackAndDefencePoints = 100;
        public Knight(string name, Point position, int owner) : base(name, position, owner)
        {
            this.HitPoints = 100;
        }

        public int AttackPoints
        {
            get { return AtackAndDefencePoints; }
        }

        public int DefensePoints
        {
            get { return AtackAndDefencePoints; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}