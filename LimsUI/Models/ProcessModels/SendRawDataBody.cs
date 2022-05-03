namespace LimsUI.Models.ProcessModels.SendRawData
{
    public class SendRawDataBody
    {
        public string messageName { get; set; }
        public Correlationkeys correlationKeys { get; set; }
        public Processvariables processVariables { get; set; }
        public bool resultEnabled { get; set; }
        public bool variablesInResultEnabled { get; set; }
    }

    public class Correlationkeys
    {
        public Elisaid elisaId { get; set; }
    }

    public class Elisaid
    {
        public int value { get; set; }
        public string type { get; set; }
    }

    public class Processvariables
    {
        public Standardsdata standardsData { get; set; }
        public Samplesdata samplesData { get; set; }
    }

    public class Standardsdata
    {
        public string value { get; set; }
        public string type { get; set; }
    }

    public class Samplesdata
    {
        public string value { get; set; }
        public string type { get; set; }
    }
}

