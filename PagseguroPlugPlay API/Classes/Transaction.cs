using System;
using Newtonsoft.Json;

namespace PagseguroPlugPlay_API.Classes
{
    public class Transaction
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("lastEventDate")]
        public DateTime LastEventDate { get; set; }

        [JsonProperty("paymentMethod")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("grossAmount")]
        public string GrossAmount { get; set; }

        [JsonProperty("discountAmount")]
        public string DiscountAmount { get; set; }

        [JsonProperty("feeAmount")]
        public string FeeAmount { get; set; }

        [JsonProperty("netAmount")]
        public string NetAmount { get; set; }

        [JsonProperty("extraAmount")]
        public string ExtraAmount { get; set; }

        [JsonProperty("escrowEndDate")]
        public DateTime EscrowEndDate { get; set; }

        [JsonProperty("installmentCount")]
        public string InstallmentCount { get; set; }

        [JsonProperty("itemCount")]
        public string ItemCount { get; set; }

        [JsonProperty("items")]
        public Items Items { get; set; }

        [JsonProperty("deviceInfo")]
        public DeviceInfo DeviceInfo { get; set; }
    }
}