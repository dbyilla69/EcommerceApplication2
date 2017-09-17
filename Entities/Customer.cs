using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication2.Entities
{
    [Table("Customer")]
    public class Customer
    {
        public Customer()
        {
            CartItems = new HashSet<CartItem>();
            Orders = new HashSet<Order>();
        }
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer Name is Required !!")]
        public string CustomerName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public DateTime? DateEntered { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}