using StudentApp2.DTOs;

namespace StudentApp2.Interfaces
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<StudentReadDto>> GetStudentsAsync();

        public Task<StudentReadDto> GetStudentByIdAsync(int studentId);

        public Task<int> UpsertStudentAsync(StudentUpsertDto dto);

        Task<bool> SoftDeleteStudentAsync(int studentId);

        Task<IEnumerable<StudentReadDto>> GetInactiveStudentsAsync();

        Task<bool> RestoreStudentAsync(int id);

    }
}
