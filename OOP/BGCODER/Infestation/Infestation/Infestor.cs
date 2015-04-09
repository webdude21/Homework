namespace Infestation
{
    using System.Collections.Generic;
    using System.Linq;

    internal abstract class Infestor : Unit
    {
        protected Infestor(string id, UnitClassification unitType, int health, int power, int aggression)
            : base(id, unitType, health, power, aggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            var infestableUnit =
                units.Where(x => x.Id != this.Id && this.CanInfest(x)).OrderBy(x => x.Health).FirstOrDefault();

            if (infestableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), infestableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        public bool CanInfest(UnitInfo unit)
        {
            return (InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification)
                    == this.UnitClassification);
        }
    }
}