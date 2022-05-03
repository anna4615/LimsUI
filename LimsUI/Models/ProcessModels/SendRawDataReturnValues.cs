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
        public Elisa elisa { get; set; }
        public Tests tests { get; set; }
        public Elisaid elisaId { get; set; }
        public Samplesdata samplesData { get; set; }
        public Plate plate { get; set; }
        public Samples samples { get; set; }
        public Standardsdata standardsData { get; set; }
    }

    //public class Elisa
    //{
    //    public string type { get; set; }
    //    public string value { get; set; }
    //    public Valueinfo valueInfo { get; set; }
    //}

    //public class Valueinfo
    //{
    //    public string objectTypeName { get; set; }
    //    public string serializationDataFormat { get; set; }
    //}

    //public class Tests
    //{
    //    public string type { get; set; }
    //    public string value { get; set; }
    //    public Valueinfo valueInfo { get; set; }
    //}


    //public class Elisaid
    //{
    //    public string type { get; set; }
    //    public int value { get; set; }
    //    public Valueinfo valueInfo { get; set; }
    //}



    //public class Samplesdata
    //{
    //    public string type { get; set; }
    //    public string value { get; set; }
    //    public Valueinfo valueInfo { get; set; }
    //}



    //public class Plate
    //{
    //    public string type { get; set; }
    //    public string value { get; set; }
    //    public Valueinfo valueInfo { get; set; }
    //}

    //public class Samples
    //{
    //    public string type { get; set; }
    //    public string value { get; set; }
    //    public Valueinfo valueInfo { get; set; }
    //}


    //public class Standardsdata
    //{
    //    public string type { get; set; }
    //    public string value { get; set; }
    //    public Valueinfo valueInfo { get; set; }
    //}

}


