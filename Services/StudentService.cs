using StudentApp2.DTOs;
using StudentApp2.Interfaces;

namespace StudentApp2.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentReadDto?> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }


        public async Task<IEnumerable<StudentReadDto>> GetStudentsAsync()
        {
            return await _studentRepository.GetStudentsAsync();
        }

        public async Task<int> UpsertStudentAsync(StudentUpsertDto dto)
        {
            return await _studentRepository.UpsertStudentAsync(dto);
        }

        public async Task<bool> SoftDeleteStudentAsync(int studentId)
        {
            return await _studentRepository.SoftDeleteStudentAsync(studentId);
        }

        public async Task<IEnumerable<StudentReadDto>> GetInactiveStudentsAsync()
        {
            return await _studentRepository.GetInactiveStudentsAsync();
        }

        public async Task<bool> RestoreStudentAsync(int id)
        {
            return await _studentRepository.RestoreStudentAsync(id);
        }


    }
}
