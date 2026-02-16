using Dapper;
using StudentApp2.DBContext;
using StudentApp2.Interfaces;
using StudentApp2.Models;
using System.Data;

namespace StudentApp2.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DapperContext _context;

        public DepartmentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            using var connection = _context.CreateConnection();

            var departments = await connection.QueryAsync<Department>(
                "sp_GetDepartments",
                commandType: CommandType.StoredProcedure);

            return departments;
        }
    }
}
