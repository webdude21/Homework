using System;

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

        public Item ProduceItem(string name)
        {
            if (this.GatheredType == ItemType.Iron)
            {
                return new Iron(name);
            }
            if (this.GatheredType == ItemType.Wood)
            {
                return new Wood(name);
            }
            return null;
        }
    }
}
