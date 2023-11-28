using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DynamicActions.ViewModels
{
    public class DynamicActionCreateLogicModel
    {
        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("expression")]
        [Required]
        public string Expression { get; set; }

        [JsonProperty("dynamicActionType")]
        [Required]
        public string DynamicActionType { get; set; }
    }

}
