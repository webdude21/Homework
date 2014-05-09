namespace People
{
    public class PeopleTests
    {
        public static void Main()
        {
            var humanGenerator = new HumanGenerator();
            humanGenerator.CreateHuman(24);
            humanGenerator.CreateHuman(23);
        }
    }
}