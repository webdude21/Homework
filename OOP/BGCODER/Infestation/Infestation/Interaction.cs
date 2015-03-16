namespace Infestation
{
    public class Interaction
    {
        public const Interaction PassiveInteraction = null;

        public Interaction(UnitInfo sourceUnitInfo, UnitInfo targetUnitInfo, InteractionType type)
        {
            this.SourceUnit = sourceUnitInfo;
            this.TargetUnit = targetUnitInfo;
            this.InteractionType = type;
        }

        public UnitInfo SourceUnit { get; private set; }

        public UnitInfo TargetUnit { get; private set; }

        public InteractionType InteractionType { get; private set; }
    }
}