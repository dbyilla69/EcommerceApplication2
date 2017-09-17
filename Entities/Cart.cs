using System.Collections.Generic;

namespace EcommerceApplication2.Entities
{
    //[Table("CartItem")]

    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
       public List<CartItem> CartItems { get; set; }
    }
}