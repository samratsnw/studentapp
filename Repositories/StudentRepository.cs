using Dapper;
using StudentApp2.DBContext;
using StudentApp2.DTOs;
using StudentApp2.Interfaces;
using System.Data;

namespace StudentApp2.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperContext _context;

        public StudentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentReadDto>> GetStudentsAsync()
        {
            using var connection = _context.CreateConnection();

            var students = await connection.QueryAsync<StudentReadDto>(
                "sp_GetStudents",
                commandType: CommandType.StoredProcedure);

            return students;
        }

        public async Task<StudentReadDto?> GetStudentByIdAsync(int id)
        {
            using var connection = _context.CreateConnection();

            var student = await connection.QueryFirstOrDefaultAsync<StudentReadDto>(
                "sp_GetStudentById",
                new { StudentId = id },
                commandType: CommandType.StoredProcedure);

            return student;
        }


        public async Task<int> UpsertStudentAsync(StudentUpsertDto dto)
        {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@StudentID", dto.StudentID);
            parameters.Add("@DepartmentId", dto.DepartmentId);
            parameters.Add("@Name", dto.Name);
            parameters.Add("@Dob", dto.Dob);
            parameters.Add("@Gender", dto.Gender);
            parameters.Add("@IsActive", dto.IsActive);

            var id = await connection.ExecuteScalarAsync<int>(
                "sp_UpsertStudent",
                parameters,
                commandType: CommandType.StoredProcedure);

            return id;
        }

        public async Task<bool> SoftDeleteStudentAsync(int studentId)
        {
            using var connection = _context.CreateConnection();

            var result = await connection.ExecuteAsync(
                "sp_SoftDeleteStudent",
                new { StudentId = studentId },
                commandType: CommandType.StoredProcedure
            );

            return result > 0;
        }

        public async Task<IEnumerable<StudentReadDto>> GetInactiveStudentsAsync()
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<StudentReadDto>(
                "sp_GetInactiveStudents",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> RestoreStudentAsync(int studentId)
        {
            using var connection = _context.CreateConnection();

            var result = await connection.ExecuteAsync(
                "sp_RestoreStudent",
                new { StudentId = studentId },
                commandType: CommandType.StoredProcedure
            );

            return result > 0;
        }



    }
}
