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
    
    public partial class Job_task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Job_task()
        {
            this.Job_Instance = new HashSet<Job_Instance>();
            this.Job_Instance_Task = new HashSet<Job_Instance_Task>();
        }
    
        public int Job_task_ID { get; set; }
        public Nullable<int> Job_ID { get; set; }
        public Nullable<int> Task_ID { get; set; }
        public Nullable<int> Job_Task_Status_ID { get; set; }
        public Nullable<int> Job_Task_Type_ID { get; set; }
    
        public virtual Job Job { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Job_Instance> Job_Instance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Job_Instance_Task> Job_Instance_Task { get; set; }
        public virtual Job_Task_Status Job_Task_Status { get; set; }
        public virtual Job_Task_Type Job_Task_Type { get; set; }
        public virtual Task Task { get; set; }
    }
}
