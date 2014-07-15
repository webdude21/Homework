namespace Zoo
{
    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, Sex sex)
            : base(name, age, sex)
        {
        }

        public string EvokeSound()
        {
            return "Waf, waf";
        }
    }
}