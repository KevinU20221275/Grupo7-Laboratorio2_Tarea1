using ClothingStore.Models;

namespace ClothingStore.Repositories.Sales
{
    public interface ISaleRepository
    {
        void Add(Sale sale);
        void Delete(int id);
        void Edit(Sale sale);
        IEnumerable<Sale> GetAll();
        Sale? GetById(int id);
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Product> GetAllProducts();
    }
}
