using ProjPract2.DTOs;

namespace ProjPract2.Interface
{
    public interface IService
    {

        Task<IEnumerable<ReadStudentDto>> GetAll();
        Task<ReadStudentDto> GetById(int id);

        Task<int> Create(CreateStudentDto student);

        Task Update(int id, UpdateStudentDto student);

        Task Delete(int id);

    }
}
