using System.Linq;
using System.Collections.Generic;

namespace TradeAndTravel
{
    class ExtendedInteractionManager : InteractionManager
    {
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords[2], actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords[3], commandWords[2], actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
            return person;
        }

        private void HandleCraftInteraction(string itemNameString, string itemTypeString, Person actor)
        {
            if (itemTypeString == "weapon" && actor.ListInventory().Any(item => item is Iron) && (actor.ListInventory().Any(item => item is Wood)))
            {
                this.AddToPerson(actor, new Weapon(itemNameString));
            }

            if (itemTypeString == "armor" && actor.ListInventory().Any(item => item is Iron))
            {
                this.AddToPerson(actor, new Armor(itemNameString));
            }
        }

        private void HandleGatherInteraction(string itemNameString, Person actor)
        {
            IGatheringLocation gatherLoc = actor.Location as IGatheringLocation;
            if (gatherLoc != null && actor.ListInventory().Any(item => item.ItemType == gatherLoc.RequiredItem))
            {
                this.AddToPerson(actor, gatherLoc.ProduceItem(itemNameString));
            }
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }
            return location;
        }
    }
}
