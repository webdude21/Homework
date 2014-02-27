
namespace TradeAndTravel
{
    public class Forest : GatheringLocation
    {
        public Forest(string name)
            : base(name, LocationType.Forest, ItemType.Wood, ItemType.Weapon)
        {
        }

        public override Item ProduceItem(string name)
        {
            return this.GatheredType == ItemType.Wood ? new Wood(name) : null;
        }
    }
}
