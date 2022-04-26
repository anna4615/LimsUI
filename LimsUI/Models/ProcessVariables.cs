namespace LimsUI.Models
{
    public class ProcessVariables
    {
        public string id { get; set; }
        public string definitionId { get; set; }
        public object businessKey { get; set; }
        public object caseInstanceId { get; set; }
        public bool ended { get; set; }
        public bool suspended { get; set; }
        public object tenantId { get; set; }
        public Variables variables { get; set; }
    }

    public class Variables
    {
        public Tests tests { get; set; }
        public Elisaid elisaId { get; set; }
        public Plate plate { get; set; }
        public Samples samples { get; set; }
    }

    public class Tests
    {
        public string type { get; set; }
        public string value { get; set; }
    }


    public class Elisaid
    {
        public string type { get; set; }
        public int value { get; set; }
    }


    public class Plate
    {
        public string type { get; set; }
        public string value { get; set; }
    }


    public class Samples
    {
        public string type { get; set; }
        public string value { get; set; }
    }
}

