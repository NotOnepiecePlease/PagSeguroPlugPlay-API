using Newtonsoft.Json;

namespace PagseguroPlugPlay_API.Classes
{
    public class PaymentMethod
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}