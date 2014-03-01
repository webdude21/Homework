
namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        private const int WolfDefaultSize = 4;
        public Wolf(string name, Point location) : base(name, location, WolfDefaultSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && (animal.Size <= WolfDefaultSize || animal.State == AnimalState.Sleeping))
            {
                return animal.GetMeatFromKillQuantity();
            }

            return 0;
        }
    }
}
