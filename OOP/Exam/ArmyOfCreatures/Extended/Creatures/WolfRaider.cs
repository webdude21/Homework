namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    internal class WolfRaider : Creature
    {
        private const int AttackPoints = 8;

        private const int DefensePoints = 5;

        private const int Health = 10;

        private const decimal DamagePoints = 3.5m;

        private const int RoundsToDealDoubleDamage = 7;

        public WolfRaider()
            : base(AttackPoints, DefensePoints, Health, DamagePoints)
        {
            this.AddSpecialty(new DoubleDamage(RoundsToDealDoubleDamage));
        }
    }
}