using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication2.Entities
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
             SubCategories  = new Collection<SubCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public  ICollection<SubCategory> SubCategories{ get; set; }



        //public virtual ICollection<Product> Products{ get; set; }
//        public  ICollection<SubCategory> SubCategories{ get; set; }
    }

}