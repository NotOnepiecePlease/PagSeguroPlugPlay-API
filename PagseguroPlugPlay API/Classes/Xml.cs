using Newtonsoft.Json;

namespace PagseguroPlugPlay_API.Classes
{
    public class Xml
    {
        [JsonProperty("@version")]
        public string Version { get; set; }

        [JsonProperty("@encoding")]
        public string Encoding { get; set; }

        [JsonProperty("@standalone")]
        public string Standalone { get; set; }
    }
}