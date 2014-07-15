namespace Zoo
{
    public class Cat : Animal, ISound
    {
        public Cat(string name, int age, Sex sex)
            : base(name, age, sex)
        {
        }

        public string EvokeSound()
        {
            return "Meow";
        }
    }
}