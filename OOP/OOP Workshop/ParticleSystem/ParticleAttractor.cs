namespace ParticleSystem
{
    public class ParticleAttractor : Particle
    {
        public int AttractionPower { get; protected set; }
        public ParticleAttractor(MatrixCoords position, MatrixCoords speed, int attractionPower) :
            base(position, speed)
        {
            this.AttractionPower = attractionPower;
        }
    }
}
