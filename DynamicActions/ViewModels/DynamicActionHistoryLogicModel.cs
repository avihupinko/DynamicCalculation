using Newtonsoft.Json;

namespace DynamicActions.ViewModels
{
    public class DynamicActionHistoryLogicModel
    {
        [JsonProperty("x")]
        public string X { get; set; }
        [JsonProperty("y")]
        public string Y { get; set; }
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
