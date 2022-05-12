using System.Text.Json.Serialization;

namespace LimsUI.Models.UIModels
{
    public class StandardData
    {
        [JsonPropertyName("measValue")]
        public float MeasureValue { get; set; }

        [JsonPropertyName("concentration")]
        public float Concentration { get; set; }
    }
}
