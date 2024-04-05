using ClothingStore.Data;
using ClothingStore.Models;
using Dapper;
using System.Data;

namespace ClothingStore.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public EmployeeRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Employee> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "spEmployee_GetAll";

                return
                    connection.Query<Employee>(
                        storeProcedure,
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public Employee? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spEmployee_GetById";

                return connection.QueryFirstOrDefault<Employee>(
                            storedProcedure,
                            new { Id = id },
                            commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Add(Employee employee)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spEmployee_Insert";

                connection.Execute(
                        storedProcedure,
                        new { employee.EmployeeFirstName, employee.EmployeeLastName, employee.Email, employee.Phone, employee.Address, employee.Salary },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Edit(Employee employee)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spEmployee_Update";

                connection.Execute(
                        storedProcedure,
                        new { employee.Id, employee.EmployeeFirstName, employee.EmployeeLastName, employee.Email, employee.Phone, employee.Address, employee.Salary },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "spEmployee_Delete";

                connection.Execute(
                        storedProcedure,
                        new { Id = id },
                        commandType: CommandType.StoredProcedure
                    );
            }
        }
    }
}
