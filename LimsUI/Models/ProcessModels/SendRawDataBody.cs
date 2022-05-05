using LimsUI.Models.ProcessModels.Variables;

namespace LimsUI.Models.ProcessModels
{
    public class SendRawDataBody
    {
        public string messageName { get; set; }
        public SendRawDataBodyCorrelationkeys correlationKeys { get; set; }
        public SendRawDataBodyProcessvariables processVariables { get; set; }
        public bool resultEnabled { get; set; }
        public bool variablesInResultEnabled { get; set; }
    }

    public class SendRawDataBodyCorrelationkeys
    {
        public ElisaId elisaId { get; set; }
    }

    public class SendRawDataBodyProcessvariables
    {
        public Standardsdata standardsData { get; set; }
        public Samplesdata samplesData { get; set; }
    }
}

