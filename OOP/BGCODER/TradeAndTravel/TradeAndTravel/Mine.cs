namespace TradeAndTravel
{
    public class Mine : GatheringLocation
    {
        public Mine(string name)
            : base(name, LocationType.Mine, ItemType.Iron, ItemType.Armor)
        {
        }

        public override Item ProduceItem(string name)
        {
            return this.GatheredType == ItemType.Iron ? new Iron(name) : null;
        }
    }
}