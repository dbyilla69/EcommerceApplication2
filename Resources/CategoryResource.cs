using System.Collections.Generic;
using System.Collections.ObjectModel;
using EcommerceApplication2.Entities;

namespace EcommerceApplication2.Resources
{
    public class CategoryResource : KeyValuePairResource
    {
        public CategoryResource()
        {
            SubCategories = new Collection<KeyValuePairResource>();
        }
        public ICollection<KeyValuePairResource> SubCategories { get; set; }


    }
}