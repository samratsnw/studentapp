using StudentApp2.Models;

namespace StudentApp2.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync();
    }
}
