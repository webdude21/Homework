namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    internal class AncientBehemoth : Creature
    {
        private const int AttackPoints = 19;

        private const int DefensePoints = 19;

        private const int Health = 300;

        private const decimal DamagePoints = 40m;

        private const int ReduceEnemyDeferencePercentage = 80;

        private const int RoundsToDoubleDefenseWhenDefending = 5;

        public AncientBehemoth() : base(AttackPoints, DefensePoints, Health, DamagePoints)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(ReduceEnemyDeferencePercentage));
            this.AddSpecialty(new DoubleDefenseWhenDefending(RoundsToDoubleDefenseWhenDefending));
        }
    }
}