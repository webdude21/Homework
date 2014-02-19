
namespace TradeAndTravel
{
    public class Forest : GatheringLocation
    {
        public Forest(string name)
            : base(name, LocationType.Forest, ItemType.Wood, ItemType.Weapon)
        {
        }
    }
}
