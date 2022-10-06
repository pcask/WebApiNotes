using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IRepositoryService _repository;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public EmployeeManager(IRepositoryService repository, ILoggerService logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges)
        {
            CheckProjectExists(projectId);

            var employees = _repository.Employee.GetAllEmployeesByProjectId(projectId, trackChanges);

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public EmployeeDto GetEmployeeById(Guid projectId, Guid employeeId, bool trackChanges)
        {
            CheckProjectExists(projectId);

            var employee = _repository.Employee.GetEmployeeById(projectId, employeeId, trackChanges);

            if (employee == null)
                throw new EmployeeNotFoundException(employeeId);

            return _mapper.Map<EmployeeDto>(employee);
        }

        private void CheckProjectExists(Guid projectId)
        {
            var project = _repository.Project.GetProjectById(projectId, trackChanges: false);

            if (project == null)
                throw new ProjectNotFoundException(projectId);
        }
    }
}
