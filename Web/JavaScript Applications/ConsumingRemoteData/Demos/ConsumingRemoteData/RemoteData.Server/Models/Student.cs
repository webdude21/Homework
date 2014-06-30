namespace RemoteData.Server.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Student
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "fname")]
        public string FirstName { get; set; }

        [DataMember(Name = "lname")]
        public string LastName { get; set; }

        [DataMember(Name = "marks")]
        public IEnumerable<Mark> Marks { get; set; }
    }
}