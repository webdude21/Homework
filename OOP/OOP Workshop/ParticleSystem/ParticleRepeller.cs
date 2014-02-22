namespace ParticleSystem
{
    class ParticleRepeller : Particle
    {
        public int RepulsionRadius { get; private set; }
        public int RepulsionPower { get; private set; }

        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int reuplsionRadius = 10, int repulsionPower = 10)
            : base(position, speed)
        {
            this.RepulsionRadius = reuplsionRadius;
            this.RepulsionPower = repulsionPower;
        }

        public override char[,] GetImage()
        {
            return new[,] { { (char)15 } };
        }
    }
}
