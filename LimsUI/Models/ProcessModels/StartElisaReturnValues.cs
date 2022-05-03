using LimsUI.Models.ProcessModels.Variables;

namespace LimsUI.Models.ProcessModels
{
    public class StartElisaReturnValues
    {
        public string id { get; set; }
        public string definitionId { get; set; }
        public object businessKey { get; set; }
        public object caseInstanceId { get; set; }
        public bool ended { get; set; }
        public bool suspended { get; set; }
        public object tenantId { get; set; }
        public StartElisaReturnVariables variables { get; set; }
    }

    public class StartElisaReturnVariables
    {
        public Tests tests { get; set; }
        public Elisaid elisaId { get; set; }
        public Plate plate { get; set; }
        public Samples samples { get; set; }
    }
}

