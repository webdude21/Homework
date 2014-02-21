
namespace TradeAndTravel
{
    public class Wood : Item
    {
        const int GeneralWoodValue = 2;

        public Wood(string name, Location location = null)
            : base(name, GeneralWoodValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            switch (interaction)
            {
                case "drop":
                    this.Value = this.Value > 0 ? this.Value = this.Value - 1 : this.Value = 0;
                    break;
                default:
                    base.UpdateWithInteraction(interaction);
                    break;
            }
        }
    }
}
