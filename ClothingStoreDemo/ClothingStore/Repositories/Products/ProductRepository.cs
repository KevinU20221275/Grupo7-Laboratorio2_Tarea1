using ClothingStore.Data;
using ClothingStore.Models;
using Dapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Data;

namespace ClothingStore.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public ProductRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            string query = "SELECT Id,CategoryName FROM Category";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<Category>(query);
            }
        }

        public IEnumerable<Size> GetAllSizes()
        {
            string query = "SELECT Id,SizeDescription FROM Size";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<Size>(query);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spProduct_GetAll";

                var products = connection.Query<Product, Category, Size, Product>(storedProcedure, (product, category, size) =>
                {
                    product.Category = category;
                    product.Size = size;

                    return product;
                },
                splitOn: "CategoryName, SizeDescription",
                commandType: CommandType.StoredProcedure);

                return products;
            }
        }

        public Product? GetById(int id)
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

        public void Add(Product product)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spProduct_Insert";

                connection.Execute(
                        storedProcedure,
                        new { product.ProductName, product.Description, product.Price, product.CategoryId, product.SizeId },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(Product product)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spProduct_Update";

                connection.Execute(
                        storedProcedure,
                        new { product.Id, product.ProductName, product.Description, product.Price, product.CategoryId, product.SizeId },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spProduct_Delete";

                connection.Execute(
                        storedProcedure,
                        new { Id = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
