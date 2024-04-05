using ClothingStore.Models;

namespace ClothingStore.Repositories.Customers
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Delete(int id);
        void Edit(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer? GetById(int id);
    }
}