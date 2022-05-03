using LimsUI.Models.ProcessModels.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimsUI.Models.ProcessModels
{
    public class GetPlateVariableReturnValues
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
}
