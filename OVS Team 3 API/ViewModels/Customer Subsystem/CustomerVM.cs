using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels
{
    public class CustomerVM
    {
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Surname { get; set; }
        public string Customer_Cellphone_Number { get; set; }
        public System.DateTime Customer_Date_Of_Birth { get; set; }
        public string Customer_Email_Address { get; set; }
        public string Customer_Physical_Address { get; set; }
        public Nullable<int> Customer_Type_ID { get; set; }
        public Nullable<int> User_ID { get; set; }
    }
}