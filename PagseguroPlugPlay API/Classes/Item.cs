using Newtonsoft.Json;

namespace PagseguroPlugPlay_API.Classes
{
    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }
    }
}