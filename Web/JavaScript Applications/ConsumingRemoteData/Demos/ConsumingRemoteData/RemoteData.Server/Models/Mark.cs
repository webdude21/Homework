namespace RemoteData.Server.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Mark
    {
        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "score")]
        public double Score { get; set; }
    }
}