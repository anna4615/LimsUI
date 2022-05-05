using LimsUI.Models.ProcessModels.Variables;

namespace LimsUI.Models.ProcessModels
{

    public class ResultReviewedBody
    {
        public string messageName { get; set; }
        public ResultReviewedBodyCorrelationkeys correlationKeys { get; set; }
        public ResultReviewedBodyProcessvariables processVariables { get; set; }
        public bool resultEnabled { get; set; }
        public bool variablesInResultEnabled { get; set; }
    }

    public class ResultReviewedBodyCorrelationkeys
    {
        public ElisaId elisaId { get; set; }
    }


    public class ResultReviewedBodyProcessvariables
    {
        public ExperimentOk experimentOk { get; set; }
        public Redo redo { get; set; }
    }
}
