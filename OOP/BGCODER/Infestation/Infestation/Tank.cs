namespace Infestation
{
    internal class Tank : Unit
    {
        private const int TankPower = 25;

        private const int TankAggression = 25;

        private const int TankHealth = 20;

        public Tank(string id)
            : base(id, UnitClassification.Mechanical, TankHealth, TankPower, TankAggression)
        {
        }
    }
}