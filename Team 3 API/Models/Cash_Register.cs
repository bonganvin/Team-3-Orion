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
    
    public partial class Cash_Register
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cash_Register()
        {
            this.Sale_Payment = new HashSet<Sale_Payment>();
        }
    
        public int Register_ID { get; set; }
        public string Cash_Register_Name { get; set; }
        public Nullable<int> Branch_ID { get; set; }
    
        public virtual Branch Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale_Payment> Sale_Payment { get; set; }
    }
}
