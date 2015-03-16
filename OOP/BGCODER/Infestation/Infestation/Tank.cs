namespace Infestation
{
    internal class Tank : Unit
    {
        const int TankPower = 25;
        const int TankAggression = 25;
        const int TankHealth = 20;

        public Tank(string id)
            : base(id, UnitClassification.Mechanical, TankHealth, TankPower, TankAggression)
        {
        }
    }
}