using System;

namespace LimsUI.Models
{
    public class Sample
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Concentration { get; set; }
        public DateTime DateAdded { get; set; }

        //public List<Test> Tests { get; set; }
    }
}
