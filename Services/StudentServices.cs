using ProjPract2.Interface;
using ProjPract2.Model;
using ProjPract2.DTOs;

namespace ProjPract2.Services
{
    public class StudentServices:IService
    {

        private readonly IRepository _repo;

        public StudentServices(IRepository repo)
        {
            _repo = repo;
        }


        public async Task<IEnumerable<ReadStudentDto>> GetAll()
        {
            var students = await _repo.GetAll();

            return students.Select(s => new ReadStudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
            });
        }

        public async Task<ReadStudentDto?> GetById(int id)
        {
            var s = await _repo.GetById(id);
            if (s == null) return null;

            return new ReadStudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age
            };

        }

        public async Task<int> Create(CreateStudentDto dto)
        {


            var student = new Student
            {
                Name = dto.Name,
                Age = dto.Age
            };

            return await _repo.Create(student);

        }

        public async Task Update(int id, UpdateStudentDto dto)
        {
            var st = await _repo.GetById(id);
            if (st == null)
                throw new Exception("Student not found");

            st.Name = dto.Name;
            st.Age = dto.Age;

            await _repo.Update(id,st);


        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }




    }
}
