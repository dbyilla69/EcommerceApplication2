using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication2.Entities
{
     [Table("Picture")]
    public class Picture
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FileName { get; set; }

         public int ProductId { get; set; }
         public bool IsMain { get; set; }

        //[ForeignKey("ProductId")]
         public Product Product{get; set;}

    }
}