
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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

        [HttpGet("{id:guid}", Name = "GetProjectById")]
        public IActionResult GetProjectById(Guid id)
        {
            var project = _service.ProjectService.GetProjectById(id, false);
            return Ok(project);
        }

        [HttpPost]
        public IActionResult CreateOneProject([FromBody] ProjectDtoForCreation projectDtoFC)
        {
            ProjectDto projectDto = _service.ProjectService.CreateOneProject(projectDtoFC);

            // CreatedAtRoute method'ı ile 201 Status Code (created response) döndürülmesi sağlıyoruz.
            return CreatedAtRoute("GetProjectById", new { id = projectDto.Id }, projectDto);
        }
    }
}
