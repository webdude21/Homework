namespace TradeAndTravel
{
    public class Mine : GatheringLocation
    {
        public Mine(string name)
            : base(name, LocationType.Mine, ItemType.Iron, ItemType.Armor)
        {
        }
    }
}
