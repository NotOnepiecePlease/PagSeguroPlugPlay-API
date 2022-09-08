using Newtonsoft.Json;

namespace PagseguroPlugPlay_API.Classes
{
    public class Moderninha
    {
        [JsonProperty("?xml")]
        public Xml Xml { get; set; }

        [JsonProperty("transaction")]
        public Transaction Transaction { get; set; }
    }
}