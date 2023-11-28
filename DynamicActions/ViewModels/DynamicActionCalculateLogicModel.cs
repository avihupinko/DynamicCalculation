using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DynamicActions.ViewModels
{
    public class DynamicActionCalculateLogicModel
    {
        [JsonProperty("dynamicActionId")]
        [Range(1, int.MaxValue)]
        public int DynamicActionId { get; set; }

        [JsonProperty("x")]
        [Required]
        public string X { get; set; }
        [JsonProperty("y")]
        [Required]
        public string Y { get; set; }
    }
}
