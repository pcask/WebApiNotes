
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace ProjectManagement.Presentation
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProjectsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                // False parametresi ile EntityFrameworkCore'un AsNoTracking method'ı aracılığıyla gelen verilerin takibi yapılmaz, bu da kaynakların 
                // serbest bırakılmasını sağlayarak bize performans artışı sağlayacaktır.
                var projects = _service.ProjectService.GetAllProjects(false);
                return Ok(projects);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error!");
            }

        }
    }
}
