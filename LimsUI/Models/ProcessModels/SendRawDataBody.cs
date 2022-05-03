﻿using LimsUI.Models.ProcessModels.Variables;

namespace LimsUI.Models.ProcessModels
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

    public class Processvariables
    {
        public Standardsdata standardsData { get; set; }
        public Samplesdata samplesData { get; set; }
    }
}
