﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels.Customer_Subsystem
{
    public class CustomerTypeVM
    {
        public int CustomerTypeID { get; set; }
       
        public string CustomerTypeDescription { get; set; }

        public int? DiscountID { get; set; }
    }
}