namespace Mobile.Models
{
    using System.Collections.Generic;

    public class Producer
    {
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; } 
    }
}