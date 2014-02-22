using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    static class ParticleSystemMain
    {
        const int SimulationRows = 30;
        const int SimulationCols = 40;

        static readonly Random RandomGenerator = new Random();

        static void Main()
        {
            var renderer = new ConsoleRenderer(SimulationRows, SimulationCols);
            var particleOperator = new MoreAdvancedParticleSystem();

            var particles = new List<Particle>
            {
                new ChaoticParticle(new MatrixCoords(15, 15), new MatrixCoords(1, 1), RandomGenerator),
                new ChickenParticle(new MatrixCoords(17, 16), new MatrixCoords(1, 1), RandomGenerator),
                new Particle(new MatrixCoords(13, 20), new MatrixCoords()),
                new ParticleRepeller(new MatrixCoords(15, 25), new MatrixCoords(), 10, 1),
                new ParticleRepeller(new MatrixCoords(10, 15), new MatrixCoords(), 10, 2),
            };

            var engine = new Engine(renderer, particleOperator, particles, 100);
            engine.Run();
        }
    }
}
