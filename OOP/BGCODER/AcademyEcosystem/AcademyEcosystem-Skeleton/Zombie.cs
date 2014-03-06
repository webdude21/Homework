namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int MeatBitten = 10;
        private const int ZombieDefaultSize = 0;
        public Zombie(string name, Point location)
            : base(name, location, ZombieDefaultSize)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return MeatBitten;
        }
    }
}
