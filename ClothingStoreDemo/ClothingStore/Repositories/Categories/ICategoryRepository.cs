using ClothingStore.Models;

namespace ClothingStore.Repositories.Categories
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Delete(int id);
        void Edit(Category category);
        IEnumerable<Category> GetAll();
        Category? GetById(int id);
    }
}