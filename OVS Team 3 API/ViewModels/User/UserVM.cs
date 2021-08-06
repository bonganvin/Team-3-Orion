using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OVS_Team_3_API.ViewModels
{
    public class UserVM
    {
        public int User_ID { get; set; }
        public string User_Password { get; set; }
        public string User_Name { get; set; }
        public Nullable<int> User_Access_Permission_ID { get; set; }
    }
}