using LimsUI.Models.ProcessModels.Variables;

namespace LimsUI.Models.ProcessModels
{
    public class StartElisaBody
    {
        public StartElisaVariables variables { get; set; }
        public bool withVariablesInReturn { get; set; }
    }

    public class StartElisaVariables
    {
        public Samples samples { get; set; }
    }
}

