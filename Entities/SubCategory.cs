using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication2.Entities
{
    [Table("SubCategory")]
    public class SubCategory
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}