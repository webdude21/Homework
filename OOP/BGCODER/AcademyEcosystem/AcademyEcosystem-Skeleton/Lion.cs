
namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        private const int LionDefaultSize = 6;
        public Lion(string name, Point location)
            : base(name, location, LionDefaultSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && (animal.Size <= (this.Size * 2)))
            {
                this.Size += 1;
                return animal.GetMeatFromKillQuantity();
            }

            return 0;
        }
    }
}
