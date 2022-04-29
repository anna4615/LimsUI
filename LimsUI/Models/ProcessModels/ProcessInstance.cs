namespace LimsUI.Models.ProcessModels
{
    public class ProcessInstance
    {
        public object[] links { get; set; }
        public string id { get; set; }
        public string definitionId { get; set; }
        public string businessKey { get; set; }
        public object caseInstanceId { get; set; }
        public bool ended { get; set; }
        public bool suspended { get; set; }
        public object tenantId { get; set; }
    }


}
