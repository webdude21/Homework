using System;
using System.Linq;

namespace Zoo
{
    /// <summary>
    /// This is a general abstract class Animal. It can be inherited, but not instantiated. 
    /// The fields are protected instead of private, so they can be inherited.
    /// </summary>
    public abstract class Animal
    {
        protected int age;
        protected Sex sex;
        protected string name;

        protected Animal(string name, int age, Sex sex)
        {
            // I've made the Animal constructor, because an Animal should not be created anyway.
            // It's descendents can still use this constructor when creating their instances.

            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public static double AvarageAge(Animal[] animals)
        {
            return animals.Average(animal => animal.Age);
        }

        public Sex Sex
        {
            get { return sex; }
            protected set { sex = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 300 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("The age of this animal can be between 0 and 300");
                }
                else
                {
                    age = value;
                }
            }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return string.Format("My name is {0}, I'm a {1}. I'm {2} and am {3} years old", this.name, 
                this.GetType().Name, this.sex, this.age);
        }
    }
}
