using Dapper;
using Microsoft.Data.SqlClient;
using StudentApp2.DTOs;
using StudentApp2.Interfaces;

public class DepartmentService : IDepartmentService
{
    private readonly IConfiguration _config;

    public DepartmentService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync()
    {
        using var conn = new SqlConnection(
            _config.GetConnectionString("DefaultConnection"));

        var sql = "SELECT DepartmentId, DepartmentName FROM Department";

        return await conn.QueryAsync<DepartmentDto>(sql);
    }
}
