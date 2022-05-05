using LimsUI.Models.ProcessModels.Variables;

namespace LimsUI.Models.ProcessModels

{
    public class SendRawDataReturnValues
    {
        public string resultType { get; set; }
        public Execution execution { get; set; }
        public object processInstance { get; set; }
        public SendRawDataReturnVariables variables { get; set; }
    }

    public class Execution
    {
        public string id { get; set; }
        public string processInstanceId { get; set; }
        public bool ended { get; set; }
        public object tenantId { get; set; }
    }

    public class SendRawDataReturnVariables
    {
        public ElisaResult elisa { get; set; }
        public Tests tests { get; set; }
        public ElisaId elisaId { get; set; }
        public Samplesdata samplesData { get; set; }
        public Plate plate { get; set; }
        public Samples samples { get; set; }
        public Standardsdata standardsData { get; set; }
    }
}


