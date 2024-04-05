using ClothingStore.Data;
using ClothingStore.Models;
using Dapper;
using System.Data;

namespace ClothingStore.Repositories.Sizes
{
    public class SizeRepository : ISizeRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public SizeRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Size> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spSize_GetAll";

                return
                    connection.Query<Size>(
                        storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public Size? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spSize_GetById";

                return connection.QueryFirstOrDefault<Size>(
                            storedProcedure,
                            new { Id = id },
                            commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Add(Size size)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spSize_Insert";

                connection.Execute(
                        storedProcedure,
                        new { size.SizeDescription },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(Size size)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spSize_Update";

                connection.Execute(
                        storedProcedure,
                        new { size.Id, size.SizeDescription },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spSize_Delete";

                connection.Execute(
                        storedProcedure,
                        new { Id = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
