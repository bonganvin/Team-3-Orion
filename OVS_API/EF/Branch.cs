using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Branch
    {
        public Branch()
        {
            CashRegisters = new HashSet<CashRegister>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int BranchLocationStorageCapacity { get; set; }
        public string BranchAddress { get; set; }

        public virtual ICollection<CashRegister> CashRegisters { get; set; }
    }
}
