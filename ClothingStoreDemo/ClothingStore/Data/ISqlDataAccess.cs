using System.Data;

namespace ClothingStore.Data
{
    public interface ISqlDataAccess
    {
        IDbConnection GetConnection();
    }
}
