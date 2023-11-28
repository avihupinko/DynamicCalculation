using Newtonsoft.Json;

namespace DynamicActions.ViewModels
{
    public class DynamicActionLogicModel: DynamicActionCreateLogicModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
