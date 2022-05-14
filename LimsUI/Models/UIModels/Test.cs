using System.ComponentModel.DataAnnotations;

namespace LimsUI.Models.UIModels
{
    public class Test
    {
        public int Id { get; set; }

        [Display(Name = "ProvId")]
        public int SampleId { get; set; }

        public int ElisaId { get; set; }
        
        [Display(Name = "Namn")]
        public string SampleName { get; set; }

        [Display(Name = "Mätvärde")]
        public float MeasureValue { get; set; }

        [Display(Name = "Koncentration (ug/ml)")]
        public float Concentration { get; set; }
        public int PlatePosition { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public Sample Sample { get; set; }

        //[Display(Name = "Godkänd")]
        //public bool approved { get; set; }

    }
}
