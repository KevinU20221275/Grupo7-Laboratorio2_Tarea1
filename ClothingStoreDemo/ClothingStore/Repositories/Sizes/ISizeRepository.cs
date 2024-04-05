using ClothingStore.Models;

namespace ClothingStore.Repositories.Sizes
{
    public interface ISizeRepository
    {
        void Add(Size size);
        void Delete(int id);
        void Edit(Size size);
        IEnumerable<Size> GetAll();
        Size? GetById(int id);
    }
}
