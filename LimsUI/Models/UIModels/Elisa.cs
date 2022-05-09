using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LimsUI.Models.UIModels
{
    public class Elisa
    {
        [JsonPropertyName("id")]
        
        public int Id { get; set; }

        public string Status { get; set; }

        public DateTime DateAdded { get; set; }

        [JsonPropertyName("tests")]
        public List<Test> Tests { get; set; }

        public bool Approved { get; set; }
        public bool Redo { get; set; }
    }
}
