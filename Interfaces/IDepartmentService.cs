using StudentApp2.DTOs;

namespace StudentApp2.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync();
    }
}
