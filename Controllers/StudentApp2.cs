using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp2.DTOs;
using StudentApp2.Interfaces;

namespace StudentApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetStudentsAsync();
            return Ok(students);
        }


        [HttpPost("upsert")]
        public async Task<IActionResult> UpsertStudent([FromBody] StudentUpsertDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid payload");

            var id = await _studentService.UpsertStudentAsync(dto);

            return Ok(new
            {
                StudentId = id,
                Message = "Upsert successful"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _studentService.SoftDeleteStudentAsync(id);
            return NoContent();   // always 204
        }

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactive()
        {
            var students = await _studentService.GetInactiveStudentsAsync();
            return Ok(students);
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> Restore(int id)
        {
            var result = await _studentService.RestoreStudentAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }





    }
}
