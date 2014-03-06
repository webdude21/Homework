namespace AcademyEcosystem
{
    public class Boar : Animal, IHerbivore, ICarnivore
    {
        private const int BoarDefaultSize = 4;
        private int biteSize;
        public Boar(string name, Point location)
            : base(name, location, BoarDefaultSize)
        {
            this.biteSize = 2;
        }

        public int EatPlant(Plant p)
        {
            if (p != null)
            {
                this.Size += 1;
                return p.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && (animal.Size <= BoarDefaultSize))
            {
                return animal.GetMeatFromKillQuantity();
            }

            return 0;
        }
    }
}
