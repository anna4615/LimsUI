using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LimsUI.Models
{
    public class Layout
    {

        [JsonPropertyName("elisaId")]
        public int ElisaId { get; set; }

        [JsonPropertyName("wells")]
        public List<Well> Wells { get; set; }
    }
}
