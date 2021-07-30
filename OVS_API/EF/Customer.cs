using System;
using System.Collections.Generic;

#nullable disable

namespace OVS_API.EF
{
    public partial class Customer
    {
        public Customer()
        {
            Carts = new HashSet<Cart>();
            CreditNotes = new HashSet<CreditNote>();
            Orders = new HashSet<Order>();
            ReturnOrderRequests = new HashSet<ReturnOrderRequest>();
            ReturnSaleRequests = new HashSet<ReturnSaleRequest>();
            Wishlists = new HashSet<Wishlist>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerCellphoneNumber { get; set; }
        public DateTime CustomerDateOfBirth { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string CustomerPhysicalAddress { get; set; }
        public int? CustomerTypeId { get; set; }
        public int? UserId { get; set; }

        public virtual CustomerType CustomerType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<CreditNote> CreditNotes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ReturnOrderRequest> ReturnOrderRequests { get; set; }
        public virtual ICollection<ReturnSaleRequest> ReturnSaleRequests { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
