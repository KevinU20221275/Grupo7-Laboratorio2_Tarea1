using ClothingStore.Data;
using ClothingStore.Models;
using Dapper;
using System.Data;

namespace ClothingStore.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public CategoryRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Category> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spCategory_GetALL";

                return
                    connection.Query<Category>(
                        storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public Category? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spCategory_GetById";

                return connection.QueryFirstOrDefault<Category>(
                            storedProcedure,
                            new { Id = id },
                            commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Add(Category category)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spCategory_Insert";

                connection.Execute(
                        storedProcedure,
                        new { category.CategoryName },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(Category category)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spCategory_Update";

                connection.Execute(
                        storedProcedure,
                        new { category.Id, category.CategoryName },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spCategory_Delete";

                connection.Execute(
                        storedProcedure,
                        new { Id = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
