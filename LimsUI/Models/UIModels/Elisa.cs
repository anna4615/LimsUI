using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LimsUI.Models.UIModels
{
    public class Elisa
    {
        
        public int Id { get; set; }

        public string Status { get; set; }

        public DateTime DateAdded { get; set; }

        public List<Test> Tests { get; set; }

        [Display(Name = "Godkänn resultatet")]
        public bool Approved { get; set; }

        [Display(Name = "Kör om ELISAn")]
        public bool Redo { get; set; }
    }
}
