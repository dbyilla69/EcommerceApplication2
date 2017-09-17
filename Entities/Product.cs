using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication2.Entities
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            OrderLines = new HashSet<OrderLine>();
            Pictures = new HashSet<Picture>();

        }
        public int Id { get; set; }
        [Required, Display(Name = "SubCategory Name")]
        [StringLength(50)]
        public string ProductName { get; set; }
        public string Details { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public byte[] ProductImagePath { get; set; }
        public int SubCategoryId { get; set; }
        public  SubCategory SubCategory{ get; set; }
        public int? PictureId { get; set; }
        public  ICollection<CartItem> CartItems { get; set; }

        public  ICollection<OrderLine> OrderLines { get; set; }
        public  ICollection<Picture> Pictures { get; set; }




    }
}