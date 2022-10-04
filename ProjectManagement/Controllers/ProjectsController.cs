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
        private readonly ILoggerService _logger;
        private readonly IRepositoryManager _repository;

        public ProjectsController(ILoggerService logger, IRepositoryManager repositoryManager)
        {
            _logger = logger; // DI with constructor method.
            _repository = repositoryManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // False parametresi ile EntityFrameworkCore'un AsNoTracking method'ı aracılığıyla gelen verilerin takibi yapılmaz, bu da kaynakların 
                // serbest bırakılmasını sağlayarak bize performans artışı sağlayacaktır.
                var projects = _repository.Project.GetAllProjects(false);

                _logger.LogInfo("Projects.Get() has been run successfully.");

                return Ok(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError("Projects.Get() has been crashed! " + ex.Message);
                throw;
            }
        }
    }
}
