using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Job_Subsystem
{
    public class RecipeVM
    {
        public int Recipe_ID { get; set; }
        public string Recipe_Description { get; set; }
        public int Quantity_produced { get; set; }
        public string Recipe_Name { get; set; }

    }
}