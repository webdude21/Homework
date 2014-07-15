namespace Zoo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This is a general abstract class Animal. It can be inherited, but not instantiated. 
    /// </summary>
    public abstract class Animal
    {
        private int age;

        private Sex sex;

        protected Animal(string name, int age, Sex sex)
        {
            // I've made the Animal constructor, because an Animal should not be created anyway.
            // It's descendents can still use this constructor when creating their instances.
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public Sex Sex
        {
            get
            {
                return this.sex;
            }

            protected set
            {
                this.sex = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value > 300 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("The age of this animal can be between 0 and 300");
                }

                this.age = value;
            }
        }

        public string Name { get; protected set; }

        public static double AvarageAge(IEnumerable<Animal> animals)
        {
            return animals.Average(animal => animal.Age);
        }

        public override string ToString()
        {
            return string.Format(
                "My name is {0}, I'm a {1}. I'm {2} and am {3} years old", 
                this.Name, 
                this.GetType().Name, 
                this.sex, 
                this.age);
        }
    }
}