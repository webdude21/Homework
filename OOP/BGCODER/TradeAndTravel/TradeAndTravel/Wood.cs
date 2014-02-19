using System.Collections.Generic;

namespace TradeAndTravel
{
    public class Wood : Item
    {
        const int GeneralWoodValue = 2;

        public Wood(string name, Location location = null)
            : base(name, Wood.GeneralWoodValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            switch (interaction)
            {
                case "drop":
                    this.Value = this.Value > 0 ? this.Value-- : this.Value = this.Value;
                    break;
                default:
                    base.UpdateWithInteraction(interaction);
                    break;
            }
        }
    }
}
