using Newtonsoft.Json;
using OVS_API.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OVS_API.ViewModels
{
    public class CustomerClass
    {
        [JsonProperty("Customer")]
        public string Customer { get; set;  }
    }
}
