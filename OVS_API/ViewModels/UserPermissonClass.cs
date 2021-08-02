using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OVS_API.ViewModels
{
    public class UserPermissonClass
    {
        [JsonProperty("UserAccessPermission")]

        public string UserAccessPermisson { get; set; }

        [JsonProperty("UserAccessID")]

        public int UserAccessID { get; set; }

    }
}
