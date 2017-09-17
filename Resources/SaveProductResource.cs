namespace EcommerceApplication2.Resources
{
    public class SaveProductResource
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Details { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        //public byte[] ProductImagePath { get; set; }
        //public CategoryResource CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        //public int? PictureId { get; set; }
    }
}