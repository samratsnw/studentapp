using ProjPract2.Model;

namespace ProjPract2.Interface
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int id);

        Task<int> Create(Student student);

        Task Update(int id,Student student);

        Task Delete(int id);



    }
}
