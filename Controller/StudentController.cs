using Microsoft.AspNetCore.Mvc;
using ProjPract2.DTOs;
using ProjPract2.Interface;

namespace ProjPract2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IService _service;

        public StudentController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadStudentDto>>> GetAll()
        {
            var students =  await _service.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadStudentDto>> GetById(int id)
        {
            var student = await _service.GetById(id);

            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto dto)
        {
            var newId = await _service.Create(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = newId },
                null
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentDto dto)
        {
            await _service.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
