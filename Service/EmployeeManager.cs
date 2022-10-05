using AutoMapper;
using Contracts;
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
            try
            {
                var employees = _repository.Employee.GetAllEmployeesByProjectId(projectId, trackChanges);
                _logger.LogError("IEmployeeService.GetAllEmployeesByProjectId() has been run successfully!");

                return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError("IEmployeeService.GetAllEmployeesByProjectId() has been crashed! " + ex.Message);
                throw;
            }

        }

        public EmployeeDto GetEmployeeById(Guid projectId, Guid employeeId, bool trackChanges)
        {
            try
            {
                var employee = _repository.Employee.GetEmployeeById(projectId, employeeId, trackChanges);
                _logger.LogError("IEmployeeService.GetEmployeeById() has been run successfully!");

                return _mapper.Map<EmployeeDto>(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError("IEmployeeService.GetEmployeeById() has been crashed! " + ex.Message);
                throw;
            }
        }
    }
}
