using Newtonsoft.Json;

// WebServiceAutomation.Model.JsonModel
namespace WebServiceAutomation.GetEndpoint
{
    public class JsonRootObject
    {
        [JsonProperty("7000")]
        public int _7000 { get; set; }

        [JsonProperty("5000")]
        public int _5000 { get; set; }
        public int placed { get; set; }
        public int @string { get; set; }

        [JsonProperty("sold ")]
        public int sold { get; set; }
        public int unavailable { get; set; }
        public int pending { get; set; }
        public int happy { get; set; }
        public int available { get; set; }
        public int delivered { get; set; }

        [JsonProperty("3000")]
        public int _3000 { get; set; }
        public int soldout { get; set; }
        public int approved { get; set; }
        public int VL4EQE { get; set; }

        [JsonProperty("available, sold")]
        public int availablesold { get; set; }
        public int available_DEV { get; set; }
        public int adf { get; set; }

        [JsonProperty("6000")]
        public int _6000 { get; set; }
        public int d { get; set; }
        public int lll { get; set; }
        public int AVAILABLE { get; set; }

        [JsonProperty("1")]
        public int _1 { get; set; }
        public int Valid { get; set; }
        public int z { get; set; }
    }
}
