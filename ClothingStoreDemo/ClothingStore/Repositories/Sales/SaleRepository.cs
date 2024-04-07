using ClothingStore.Data;
using ClothingStore.Models;
using Dapper;
using System.Data;

namespace ClothingStore.Repositories.Sales
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public SaleRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            string query = "SELECT Id, CustomerFirstName + ' ' + CustomerLastName AS CustomerName FROM Customer";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<Customer>(query);
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            string query = "SELECT Id, EmployeeFirstName + ' ' + EmployeeLastName AS EmployeeName FROM Employee";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<Employee>(query);
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            string query = "SELECT Id, ProductName + '      $' + CAST(Price AS VARCHAR(10)) AS ProductInfo FROM Product;";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<Product>(query);
            }
        }

        // trae datos de cliente para el mensaje de correo electronico
        public Customer? GetCustomerById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spCustumer_GetById";

                return connection.QueryFirstOrDefault<Customer>(
                            storedProcedure,
                            new { Id = id },
                            commandType: CommandType.StoredProcedure
                    );
            }
        }

        // trae datos de producto para el mensaje de correo electronico
        public Product? GetProductById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spProduct_GetById";

                return connection.QueryFirstOrDefault<Product>(
                            storedProcedure,
                            new { Id = id },
                            commandType: CommandType.StoredProcedure
                    );
            }
        }


        public IEnumerable<Sale> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spSale_GetAll";

                var sales = connection.Query<Sale, Customer, Employee, Product, Sale>(storedProcedure, (sale,customer,employee,product) =>
                {
                    sale.Customer = customer;
                    sale.Employee = employee;
                    sale.Product = product;

                    return sale;
                },
                splitOn: "CustomerName,EmployeeName,ProductName",
                commandType: CommandType.StoredProcedure);

                return sales;
            }
        }

        public Sale? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spSale_GetById";

                return connection.QueryFirstOrDefault<Sale>(
                            storedProcedure,
                            new { Id = id },
                            commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Add(Sale sale)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spSale_Insert";

                connection.Execute(
                        storedProcedure,
                        new { sale.CustomerId, sale.EmployeeId, sale.ProductId, sale.Quantity, sale.SaleDate },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(Sale sale)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spSale_Update";

                connection.Execute(
                        storedProcedure,
                        new { sale.Id, sale.CustomerId, sale.EmployeeId, sale.ProductId, sale.Quantity, sale.SaleDate },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spSale_Delete";

                connection.Execute(
                        storedProcedure,
                        new { Id = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
