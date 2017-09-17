using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication2.Entities
{
    [Table("CartItem")]
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Price { get; set; }
        public decimal? ProductId { get; set; }
    }
}