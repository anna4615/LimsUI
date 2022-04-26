using System.Text.Json.Serialization;

namespace LimsUI.Models
{
    public class Well
    {
        [JsonPropertyName("pos")]
        public int Position { get; set; }

        [JsonPropertyName("wellName")]
        public string WellName { get; set; }

        [JsonPropertyName("reagent")]
        public string Reagent { get; set; }

    }
}
