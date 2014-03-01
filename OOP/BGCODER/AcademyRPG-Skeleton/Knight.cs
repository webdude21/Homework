namespace AcademyRPG
{
    public class Knight : Guard, IFighter
    {
        private const int AtackAndDefencePoints = 100;
        public Knight(string name, Point position, int owner) : base(name, position, owner)
        {
        }

        int IFighter.AttackPoints
        {
            get { return AtackAndDefencePoints; }
        }

        int IFighter.DefensePoints
        {
            get { return AtackAndDefencePoints; }
        }

        public new int AttackPoints
        {
            get
            {
                return AtackAndDefencePoints;
            }
        }

        public new int DefensePoints
        {
            get
            {
                return AtackAndDefencePoints;
            }
        }
    }
}