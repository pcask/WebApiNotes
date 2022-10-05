using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace ProjectManagement.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IServiceManager _service;

        // DI with constructor method.
        public ProjectsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // False parametresi ile EntityFrameworkCore'un AsNoTracking method'ı aracılığıyla gelen verilerin takibi yapılmaz, bu da kaynakların 
            // serbest bırakılmasını sağlayarak bize performans artışı sağlayacaktır.
            var projects = _service.ProjectService.GetAllProjects(false);

            return Ok(projects);
        }
    }
}
