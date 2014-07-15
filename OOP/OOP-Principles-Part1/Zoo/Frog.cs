namespace Zoo
{
    public class Frog : Animal, ISound
    {
        public Frog(string name, int age, Sex sex)
            : base(name, age, sex)
        {
        }

        public string EvokeSound()
        {
            return "Ribbit, ribbit!";
        }
    }
}