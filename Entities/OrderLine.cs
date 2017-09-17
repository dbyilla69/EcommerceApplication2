using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication2.Entities
{
    [Table("OrderLine")]
    public class OrderLine
    {
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        [Range(1, 100,ErrorMessage="Price must be between {0} and {1}")]
        public decimal? Price { get; set; }
         public int? OrderId { get; set; }
         public int? ProductId { get; set; }
        public virtual Order Orders { get; set; }
        public virtual Product Products { get; set; }
    }
}