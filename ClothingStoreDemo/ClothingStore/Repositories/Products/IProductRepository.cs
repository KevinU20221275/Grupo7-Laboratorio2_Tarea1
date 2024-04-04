using ClothingStore.Models;

namespace ClothingStore.Repositories.Products
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Edit(Product product);
        void Delete(int id);
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        IEnumerable<Size> GetAllSizes();
        IEnumerable<Category> GetAllCategories();
    }
}
