namespace School
{
    public abstract class Person
    {
        // I've made this field protected in order to have access to it when the class has been inherited
        protected string name; 

        public string Name
        {
            get { return name; }
        }
    }
}
