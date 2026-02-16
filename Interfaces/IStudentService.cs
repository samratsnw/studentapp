using StudentApp2.DTOs;

namespace StudentApp2.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentReadDto>> GetStudentsAsync();

        public Task<StudentReadDto> GetStudentByIdAsync(int id);

        Task<int> UpsertStudentAsync(StudentUpsertDto dto);

        Task<bool> SoftDeleteStudentAsync(int studentId);

        Task<IEnumerable<StudentReadDto>> GetInactiveStudentsAsync();

        Task<bool> RestoreStudentAsync(int id);
    }
}
