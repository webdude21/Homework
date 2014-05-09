namespace People
{
    public class HumanGenerator
    {
        public enum Gender
        {
            Male, Female
        }

        public void CreateHuman(int age)
        {
            var newHuman = new Human { Age = age };
            if (age % 2 == 0)
            {
                newHuman.Name = "Ash";
                newHuman.Gender = Gender.Male;
            }
            else
            {
                newHuman.Name = "Misty";
                newHuman.Gender = Gender.Female;
            }
        }

        public class Human
        {
            public Gender Gender { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}