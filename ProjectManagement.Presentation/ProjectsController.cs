
using Entities.Models;
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
            // False parametresi ile EntityFrameworkCore'un AsNoTracking method'ı aracılığıyla gelen verilerin takibi yapılmaz, bu da kaynakların 
            // serbest bırakılmasını sağlayarak bize performans artışı sağlayacaktır.
            var projects = _service.ProjectService.GetAllProjects(false);
            return Ok(projects);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetProjectById(Guid id)
        {
            var project = _service.ProjectService.GetProjectById(id, false);
            return Ok(project);
        }
    }
}
