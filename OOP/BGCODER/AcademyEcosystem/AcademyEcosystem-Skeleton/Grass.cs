namespace AcademyEcosystem
{
    public class Grass : Plant
    {
        private const int DefaultGrassSize = 2;
        private const int GrassGrowRate = 1;
        public Grass(Point location)
            : base(location, DefaultGrassSize)
        {
        }

        public override void Update(int time)
        {
            if (IsAlive)
            {
                this.Size = this.Size + (time * GrassGrowRate);
            }
        }
    }
}
