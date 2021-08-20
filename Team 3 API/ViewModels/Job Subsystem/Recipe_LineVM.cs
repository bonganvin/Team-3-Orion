using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Job_Subsystem
{
    public class Recipe_LineVM
    {
        public int Reciple_Line_ID { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> Recipe_ID { get; set; }
        public Nullable<int> Raw_Material_ID { get; set; }
        public Nullable<int> Recipe_Line_unit_ID { get; set; }
    }
}