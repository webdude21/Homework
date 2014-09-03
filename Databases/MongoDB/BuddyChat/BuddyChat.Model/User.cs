namespace BuddyChat.Model
{
    using System;

    public class User
    {
        public User(string name)
        {
            this.Name = name;
            this.LoggedOn = DateTime.Now.ToUniversalTime();
        }

        public string Name { get; set; }

        public DateTime LoggedOn { get; set; }
    }
}