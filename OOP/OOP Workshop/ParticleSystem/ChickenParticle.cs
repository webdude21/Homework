/* Create a ChickenParticle class. The ChickenParticle class moves like a ChaoticParticle, 
 * but randomly stops at different positions for several simulation ticks and, for each of those 
 * stops, creates (lays) a new ChickenParticle. You are not allowed to edit any existing class. */

using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    public class ChickenParticle : ChaoticParticle
    {
        private const int ChanceNumber = 55;
        private const int TicksToHatch = 10;
        private int ticksLeftToHatch;
        public bool Hatching { get; private set; }

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            : base(position, speed, randomGenerator)
        {
        }

        private bool RandomEventHappens
        {
            get { return RandomGenerator.Next(0, 1000) % ChanceNumber == 0; }
        }

        public override IEnumerable<Particle> Update()
        {
            if (this.Hatching)
            {
                ticksLeftToHatch--;
                if (ticksLeftToHatch == 0)
                {
                    this.Hatching = false;
                    return new List<Particle> { CreateBabyChick() };
                }
                return base.Update();
            }

            if (RandomEventHappens)
            {
                this.Hatching = true;
                this.ticksLeftToHatch = TicksToHatch;
            }
            return base.Update();
        }

        protected override void Move()
        {
            if (!Hatching)
            {
                base.Move();
            }
        }

        private ChickenParticle CreateBabyChick()
        {
            return new ChickenParticle(this.Position, this.Speed, this.RandomGenerator);
        }

        public override char[,] GetImage()
        {
            return new[,] { { '^' } };
        }
    }
}
