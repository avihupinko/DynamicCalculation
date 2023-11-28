using Newtonsoft.Json;

namespace DynamicActions.ViewModels
{
    public class DynamicActionCalculateResultLogicModel
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("max")]
        public decimal Max { get; set; }

        [JsonProperty("min")]
        public decimal Min { get; set; }

        [JsonProperty("avg")]
        public decimal Avg { get; set; }

        [JsonProperty("lastMonth")]
        public decimal LastMonth { get; set; }
    }
}
