using ClothingStore.Data;
using ClothingStore.Models;
using Dapper;
using System.Data;

namespace ClothingStore.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public CustomerRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Customer> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "SP_GetCustomers";

                return
                    connection.Query<Customer>(
                        storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public Customer? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spProduct_GetById";

                return connection.QueryFirstOrDefault<Customer>(
                            storedProcedure,
                            new { CustomerId = id },
                            commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Add(Customer customer)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "SP_InsertCustomer";

                connection.Execute(
                        storedProcedure,
                        new { customer.CustomerFirstName, customer.CustomerLastName, customer.Email, customer.Phone, customer.Address },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(Customer customer)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "SP_UpdateCustomer";

                connection.Execute(
                        storedProcedure,
                        new { customer.CustomerFirstName, customer.CustomerLastName, customer.Email, customer.Phone, customer.Address },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "SP_DeleteCustomer";

                connection.Execute(
                        storedProcedure,
                        new { CustomerId = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
