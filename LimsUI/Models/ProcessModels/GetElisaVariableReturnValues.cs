using LimsUI.Models.ProcessModels.Variables;


namespace LimsUI.Models.ProcessModels
{



    public class GetElisaVariableReturnValues
    {
        public string type { get; set; }
        public ElisaValue value { get; set; }
        public Valueinfo valueInfo { get; set; }
    }

    public class ElisaValue
    {
        public int id { get; set; }
        public Test[] tests { get; set; }
        public string status { get; set; }
    }

    public class Test
    {
        public int id { get; set; }
        public int sampleId { get; set; }
        public int elisaId { get; set; }
        public string sampleName { get; set; }
        public float measureValue { get; set; }
        public float concentration { get; set; }
        public int platePosition { get; set; }
        public string status { get; set; }
    }





}
