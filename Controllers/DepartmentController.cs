using Microsoft.AspNetCore.Mvc;
using StudentApp2.Interfaces;

namespace StudentApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetDepartmentsAsync();
            return Ok(data);
        }
    }
}
