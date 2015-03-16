namespace Infestation
{
    public class ExtendedHoldingPen : HoldingPen
    {
        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    var targetUnit = this.GetUnit(interaction.TargetUnit);
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "AggressionCatalyst":
                    this.AddSupplementToUnit(commandWords[2], new AggressionCatalyst());
                    break;
                case "PowerCatalyst":
                    this.AddSupplementToUnit(commandWords[2], new PowerCatalyst());
                    break;
                case "HealthCatalyst":
                    this.AddSupplementToUnit(commandWords[2], new HealthCatalyst());
                    break;
                case "Weapon":
                    this.AddSupplementToUnit(commandWords[2], new Weapon());
                    break;
            }
        }

        private void AddSupplementToUnit(string unitId, ISupplement supplement)
        {
            var unit = this.GetUnit(unitId);
            if (unit != null)
            {
                unit.AddSupplement(supplement);
            }
        }
    }
}