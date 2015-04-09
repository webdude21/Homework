namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            var infestableUnit =
                units.Where(x => x.Id != this.Id && this.Aggression >= x.Power)
                    .OrderByDescending(x => x.Health)
                    .FirstOrDefault();

            if (infestableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), infestableUnit, InteractionType.Attack);
            }

            return Interaction.PassiveInteraction;
        }
    }
}