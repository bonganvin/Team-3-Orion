using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class CashRegister
    {
        public CashRegister()
        {
            SalePayments = new HashSet<SalePayment>();
        }

        public int RegisterId { get; set; }
        public string CashRegisterName { get; set; }
        public int? BranchId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ICollection<SalePayment> SalePayments { get; set; }
    }
}
