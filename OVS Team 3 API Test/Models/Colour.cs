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
    
    public partial class Colour
    {
        public int Colour_ID { get; set; }
        public string Colour_Description { get; set; }
        public Nullable<int> Product_Size_ID { get; set; }
    
        public virtual Product_Size Product_Size { get; set; }
    }
}
