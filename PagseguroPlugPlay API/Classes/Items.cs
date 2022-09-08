using Newtonsoft.Json;

namespace PagseguroPlugPlay_API.Classes
{
    public class Items
    {
        [JsonProperty("item")]
        public Item Item { get; set; }
    }
}