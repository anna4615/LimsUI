﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsUI.Models.ProcessModels
{
    public class PlateVariable
    {
        public string type { get; set; }
        public Value value { get; set; }
        public Valueinfo valueInfo { get; set; }
    }

    public class Value
    {
        public int elisaId { get; set; }
        public Well[] wells { get; set; }
    }

    public class Well
    {
        public int pos { get; set; }
        public string wellName { get; set; }
        public string reagent { get; set; }
    }

    public class Valueinfo
    {
        public string objectTypeName { get; set; }
        public string serializationDataFormat { get; set; }
    }

}
