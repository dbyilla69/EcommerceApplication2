using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EcommerceApplication2.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Details { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        //public byte[] ProductImagePath { get; set; }
        public KeyValuePairResource SubCategory { get; set; }
        public KeyValuePairResource Category { get; set; }


    }
}