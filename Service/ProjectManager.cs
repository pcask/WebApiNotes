﻿using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service
{
    public class ProjectManager : IProjectService
    {
        private readonly IRepositoryService _repository;
        private readonly ILoggerService _logger;

        public ProjectManager(IRepositoryService repository, ILoggerService logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Project> GetAllProjects(bool trackChanges)
        {
            try
            {
                var projects = _repository.Project.GetAllProjects(trackChanges);

                _logger.LogInfo("IProjectService.GetAllProjects() has been run successfully.");
                return projects;
            }
            catch (Exception ex)
            {
                _logger.LogError("IProjectService.GetAllProjects() has been crashed! " + ex.Message);
                throw;
            }
        }

        public Project GetProjectById(Guid id, bool trackChanges)
        {
            try
            {
                var project = _repository.Project.GetProjectById(id, trackChanges);

                _logger.LogInfo("IProjectService.GetProjectById() has been run successfully.");
                return project;
            }
            catch (Exception ex)
            {
                _logger.LogError("IProjectService.GetProjectById() has been crashed! " + ex.Message);
                throw;
            }
        }
    }
}