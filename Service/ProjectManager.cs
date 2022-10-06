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
            var projects = _repository.Project.GetAllProjects(trackChanges);
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public ProjectDto GetProjectById(Guid id, bool trackChanges)
        {
            var project = _repository.Project.GetProjectById(id, trackChanges);
            return _mapper.Map<ProjectDto>(project);
        }
    }
}