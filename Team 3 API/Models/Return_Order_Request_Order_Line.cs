//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OVS_Team_3_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Return_Order_Request_Order_Line
    {
        public int Return_Order_Request_Order_Line_ID { get; set; }
        public Nullable<int> Return_Order_Request_ID { get; set; }
        public Nullable<int> Order_Line_ID { get; set; }
        public string Return_Reason { get; set; }
        public int Quantity { get; set; }
    
        public virtual Order_Line Order_Line { get; set; }
        public virtual Return_Order_Request Return_Order_Request { get; set; }
    }
}
