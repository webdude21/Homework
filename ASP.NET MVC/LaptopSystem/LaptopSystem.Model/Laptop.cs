namespace LaptopSystem.Model
{
    public class Laptop
    {

        public int Id { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}