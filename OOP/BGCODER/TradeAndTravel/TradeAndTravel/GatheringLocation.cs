namespace TradeAndTravel
{
    public abstract class GatheringLocation : Location, IGatheringLocation
    {
        protected GatheringLocation(string name, LocationType location, ItemType gatheredType, ItemType requieredType)
            : base(name, location)
        {
            this.GatheredType = gatheredType;
            this.RequiredItem = requieredType;
        }
        public ItemType GatheredType { get; protected set; }

        public ItemType RequiredItem { get; protected set; }

        public abstract Item ProduceItem(string name);

    }
}
