using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IProjectService
    {
        IEnumerable<ProjectDto> GetAllProjects(bool trackChanges);
        ProjectDto GetProjectById(Guid id, bool trackChanges);
        ProjectDto CreateOneProject(ProjectDtoForCreation projectDtoFC);
    }
}