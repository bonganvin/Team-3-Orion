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
    
    public partial class Return_Sale_Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Return_Sale_Request()
        {
            this.Return_Sale_Request_Sale_Line = new HashSet<Return_Sale_Request_Sale_Line>();
        }
    
        public int Return_Sale_Request_ID { get; set; }
        public System.DateTime Return_Request_Date { get; set; }
        public Nullable<int> Customer_ID { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Return_Sale_Request_Sale_Line> Return_Sale_Request_Sale_Line { get; set; }
    }
}
