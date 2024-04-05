using ClothingStore.Models;

namespace ClothingStore.Repositories.Employees
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Delete(int id);
        void Edit(Employee employee);
        IEnumerable<Employee> GetAll();
        Employee? GetById(int id);
    }
}