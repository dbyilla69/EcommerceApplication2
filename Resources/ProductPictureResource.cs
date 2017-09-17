using System.Collections.Generic;
using EcommerceApplication2.Entities;

namespace EcommerceApplication2.Resources
{
    public class ProductPictureResource
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
          public int PictureId { get; set; }
          public string FileName { get; set; }
        public bool IsMain { get; set; }




    }
}