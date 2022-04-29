namespace LimsUI.Models.ProcessModels.StartElisa
{
    public class StartElisaBody
    {

        public Variables variables { get; set; }
        public bool withVariablesInReturn { get; set; }
    }

    public class Variables
    {
        public Samples samples { get; set; }
    }

    public class Samples
    {
        public string type { get; set; }
        public string value { get; set; }
    }

}

