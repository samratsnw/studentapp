using ProjPract2.Interface;
using ProjPract2.Model;
using Dapper;
using ProjPract2.Data;

namespace ProjPract2.Services
{
    public class StudentRepository : IRepository
    {
        private readonly DapperContext _context;

        public StudentRepository(DapperContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Student>> GetAll()
        {
            var sql = "SELECT * FROM Students";

            using var conn = _context.CreateConnection();
            return await conn.QueryAsync<Student>(sql);

        }


        public async Task<Student?> GetById(int id)
        {
            var sql = "SELECT Id, Name, Age FROM Students WHERE Id = @Id";

            using var conn = _context.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<Student>(sql, new { Id = id });
        }

        public async Task<int> Create(Student student)
        {
            var sql = @"
            INSERT INTO Students (Name, Age)
            VALUES (@Name, @Age);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";

            using var conn = _context.CreateConnection();
            return await conn.ExecuteScalarAsync<int>(sql, student);
        }

        public async Task Update(int id,Student student)
        {
            var sql = @"
            UPDATE Students
            SET Name = @Name,
                Age = @Age
            WHERE Id = @Id
        ";

            using var conn = _context.CreateConnection();
            await conn.ExecuteAsync(sql, student);
        }

        public async Task Delete(int id)
        {
            var sql = "DELETE FROM Students WHERE Id = @Id";

            using var conn = _context.CreateConnection();
            await conn.ExecuteAsync(sql, new { Id = id });
        }

    }
}
