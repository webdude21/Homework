namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    internal class Griffin : Creature
    {
        private const int AttackPoints = 8;

        private const int DefensePoints = 8;

        private const int Health = 25;

        private const decimal DamagePoints = 4.5m;

        private const int DefenseToAddWhenDefending = 5;

        private const int DefenseToAddWhenSkipping = 3;

        public Griffin() : base(AttackPoints, DefensePoints, Health, DamagePoints)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(DefenseToAddWhenDefending));
            this.AddSpecialty(new AddDefenseWhenSkip(DefenseToAddWhenSkipping));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}