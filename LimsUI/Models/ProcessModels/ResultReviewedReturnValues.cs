using LimsUI.Models.ProcessModels.Variables;

namespace LimsUI.Models.ProcessModels
{


    public class ResultReviewedReturnValues
    {
        public string resultType { get; set; }
        public ResultReviewedReturnValuesExecution execution { get; set; }
        public object processInstance { get; set; }
        public ResultReviewedReturnValuesVariables variables { get; set; }
    }

    public class ResultReviewedReturnValuesExecution
    {
        public string id { get; set; }
        public string processInstanceId { get; set; }
        public bool ended { get; set; }
        public object tenantId { get; set; }
    }

    public class ResultReviewedReturnValuesVariables
    {
        public ElisaResult elisa { get; set; }
        public Tests tests { get; set; }
        public ElisaId elisaId { get; set; }
        public Samplesdata samplesData { get; set; }
        public Plate plate { get; set; }
        public ExperimentOk experimentOk { get; set; }
        public Redo redo { get; set; }
        public Samples samples { get; set; }
        public Standardsdata standardsData { get; set; }
    }
}
