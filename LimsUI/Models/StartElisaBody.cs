namespace LimsUI.Models.StartElisaMutation
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

