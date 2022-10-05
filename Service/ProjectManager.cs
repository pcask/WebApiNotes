using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class ProjectManager : IProjectService
    {
        private readonly IRepositoryService _repository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public ProjectManager(IRepositoryService repository, ILoggerService logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ProjectDto> GetAllProjects(bool trackChanges)
        {
            try
            {
                var projects = _repository.Project.GetAllProjects(trackChanges);

                _logger.LogInfo("IProjectService.GetAllProjects() has been run successfully.");
                return _mapper.Map<IEnumerable<ProjectDto>>(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError("IProjectService.GetAllProjects() has been crashed! " + ex.Message);
                throw;
            }
        }

        public ProjectDto GetProjectById(Guid id, bool trackChanges)
        {
            try
            {
                var project = _repository.Project.GetProjectById(id, trackChanges);

                _logger.LogInfo("IProjectService.GetProjectById() has been run successfully.");
                return _mapper.Map<ProjectDto>(project);
            }
            catch (Exception ex)
            {
                _logger.LogError("IProjectService.GetProjectById() has been crashed! " + ex.Message);
                throw;
            }
        }
    }
}