using Newtonsoft.Json;

namespace PagseguroPlugPlay_API.Classes
{
    public class DeviceInfo
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("bin")]
        public string Bin { get; set; }

        [JsonProperty("holder")]
        public string Holder { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }
    }
}