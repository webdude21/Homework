namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    internal class CyclopsKing : Creature
    {
        private const int AttackPoints = 17;

        private const int DefensePoints = 13;

        private const int Health = 70;

        private const decimal DamagePoints = 18m;

        private const int AttackToAdd = 3;

        private const int RoundsToDoubleAttackWhenAttacking = 4;

        private const int RoundsToDoubleDemage = 1;

        public CyclopsKing()
            : base(AttackPoints, DefensePoints, Health, DamagePoints)
        {
            this.AddSpecialty(new AddAttackWhenSkip(AttackToAdd));
            this.AddSpecialty(new DoubleAttackWhenAttacking(RoundsToDoubleAttackWhenAttacking));
            this.AddSpecialty(new DoubleDamage(RoundsToDoubleDemage));
        }
    }
}