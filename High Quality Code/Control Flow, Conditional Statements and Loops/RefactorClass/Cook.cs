namespace RefactorClass
{
    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();
            Bowl bowl = this.GetBowl();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private void Peel(Potato potato)
        {
            // ...
        }

        private Bowl GetBowl()
        {
            // ... 
        }

        private Carrot GetCarrot()
        {
            // ...
        }

        private void Cut(Vegetable potato)
        {
            // ...
        }

        private Potato GetPotato()
        {
            // ...
        }
    }
}