namespace ClothingStore.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set;}

        public int CategoryId { get; set; }

        public int SizeId { get; set; }

        public CategoryModel? CategoryModel { get; set; }

        public SizeModel? SizeModel { get; set; }


    }
}
