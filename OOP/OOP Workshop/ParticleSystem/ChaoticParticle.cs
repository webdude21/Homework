// Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed).
// You are not allowed to edit any existing class.

using System;

namespace ParticleSystem
{
    public class ChaoticParticle : Particle
    {
        public Random RandomGenerator { get; protected set; }
        private const int RangdomRange = 2;

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            : base(position, speed)
        {
            this.RandomGenerator = randomGenerator;
        }

        protected override void Move()
        {
            GenrateRandomSpeed();
            base.Move();
        }


        private void GenrateRandomSpeed()
        {
            var x = RandomGenerator.Next(-RangdomRange + 1, RangdomRange);
            var y = RandomGenerator.Next(-RangdomRange + 1, RangdomRange);
            this.Speed = new MatrixCoords(x, y);

            // this makes the particle fly off the screen very rapidly
            // this.Accelerate(new MatrixCoords(x, y));
        }

        public override char[,] GetImage()
        {
            return new[,] { { '+' } };
        }
    }
}
