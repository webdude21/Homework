namespace AcademyRPG
{
    public class Knight : Guard, IFighter
    {
        public Knight(string name, Point position, int owner) : base(name, position, owner)
        {
        }

        int IFighter.AttackPoints
        {
            get { return 100; }
        }

        int IFighter.DefensePoints
        {
            get { return 100; }
        }

        public new int AttackPoints
        {
            get
            {
                return 100;
            }
        }

        public new int DefensePoints
        {
            get
            {
                return 100;
            }
        }
    }
}