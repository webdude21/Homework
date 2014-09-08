namespace Cars.Import.JSON.Model
{
    using Newtonsoft.Json;

    public class JsonCar
    {
        public int Year { get; set; }

        [JsonProperty("TransmissionType")]
        public int TransmisionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public JsonDealer Dealer { get; set; }
    }
}