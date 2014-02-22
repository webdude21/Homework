using System.Collections.Generic;

namespace ParticleSystem
{
    public class MoreAdvancedParticleSystem : ParticleUpdater
    {
        private readonly List<Particle> currentTickPartciles = new List<Particle>();
        private readonly List<ParticleRepeller> currentTickRepellers = new List<ParticleRepeller>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var reppelerParticle = p as ParticleRepeller;

            if (reppelerParticle != null)
            {
                this.currentTickRepellers.Add(reppelerParticle);
            }
            else
            {
                this.currentTickPartciles.Add(p);
            }
            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in this.currentTickRepellers)
            {
                foreach (var regularParticle in this.currentTickPartciles)
                {
                    if (IsInRange(regularParticle, repeller))
                    {
                        Reppel(regularParticle, repeller);
                    }
                }
            }

            this.currentTickPartciles.Clear();
            this.currentTickRepellers.Clear();

            base.TickEnded();
        }
        private static bool IsInRange(Particle particle, ParticleRepeller repeller)
        {
            return particle.Position.Row > repeller.Position.Row - repeller.RepulsionRadius
                   && particle.Position.Row < repeller.Position.Row + repeller.RepulsionRadius
                   && particle.Position.Col > repeller.Position.Col - repeller.RepulsionRadius
                   && particle.Position.Col < repeller.Position.Col + repeller.RepulsionRadius;
        }

        private void Reppel(Particle particle, ParticleRepeller repeller)
        {
            var yDirection = repeller.RepulsionPower;
            var xDirection = repeller.RepulsionPower;

            if (particle.Position.Row - repeller.Position.Row < 0)
            {
                yDirection = -yDirection;
            }

            if (particle.Position.Col - repeller.Position.Col < 0)
            {
                xDirection = -xDirection;
            }

            particle.Accelerate(new MatrixCoords(yDirection, xDirection));
        }
    }
}