using System.ComponentModel.DataAnnotations;

namespace LimsUI.Models.UIModels
{
    public class Test
    {
        public int id { get; set; }

        [Display(Name = "ProvId")]
        public int sampleId { get; set; }

        public int elisaId { get; set; }
        
        [Display(Name = "Namn")]
        public string sampleName { get; set; }

        [Display(Name = "Mätvärde")]
        public float measureValue { get; set; }

        [Display(Name = "Koncentration (ug/ml)")]
        public float concentration { get; set; }
        public int platePosition { get; set; }

        [Display(Name = "Status")]
        public string status { get; set; }

        //[Display(Name = "Godkänd")]
        //public bool approved { get; set; }

    }
}
