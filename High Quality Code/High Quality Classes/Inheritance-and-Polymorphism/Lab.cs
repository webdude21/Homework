namespace InheritanceAndPolymorphism
{
    public class Lab : ILocation
    {
        public Lab(string locationName)
        {
            this.LocationName = locationName;
            this.LocationType = "Lab";
        }
        
        public string LocationType { get; set; }

        public string LocationName { get; set; }
    }
}