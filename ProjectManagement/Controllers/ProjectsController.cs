using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly List<Project> _projects;
        private readonly ILoggerService _logger;

        public ProjectsController(ILoggerService logger)
        {
            _projects = new List<Project>()
            {
                new Project{ Id = Guid.NewGuid(), Name = "Project 1" },
                new Project{ Id = Guid.NewGuid(), Name = "Project 2" },
                new Project{ Id = Guid.NewGuid(), Name = "Project 3" },
            };

            _logger = logger; // DI with constructor method.
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                int z = 0;
                int r = 10 / z;

                _logger.LogInfo("Projects.Get() has been run successfully.");

                return Ok(_projects);
            }
            catch (Exception ex)
            {
                _logger.LogError("Projects.Get() has been crashed! " + ex.Message);
                throw;
            }
        }
    }
}
