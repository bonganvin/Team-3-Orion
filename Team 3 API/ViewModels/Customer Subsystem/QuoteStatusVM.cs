using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OVS_Team_3_API.ViewModels
{
    public class QuoteStatusVM : Controller
    {
        // GET: QuoteStatusVM
        public int Quote_Status_ID { get; set; }
        public string Quote_Status_Description { get; set; }
    }
}