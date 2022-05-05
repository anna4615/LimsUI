using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LimsUI.Models.UIModels
{
    public class Result
    {
        [JsonPropertyName("id")]
        
        public int ElisaId { get; set; }

        [JsonPropertyName("tests")]
        public List<Test> Tests { get; set; }

        public bool Approved { get; set; }
        public bool Redo { get; set; }
    }
}
