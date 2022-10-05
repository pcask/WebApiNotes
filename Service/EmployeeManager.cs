using Contracts;
using Entities.Models;
using Service.Contracts;
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

        public EmployeeManager(IRepositoryService repository, ILoggerService logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Employee> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges)
        {
            try
            {
                var employees = _repository.Employee.GetAllEmployeesByProjectId(projectId, trackChanges);
                _logger.LogError("IEmployeeService.GetAllEmployeesByProjectId() has been run successfully!");

                return employees;
            }
            catch (Exception ex)
            {
                _logger.LogError("IEmployeeService.GetAllEmployeesByProjectId() has been crashed! " + ex.Message);
                throw;
            }

        }

        public Employee GetEmployeeById(Guid projectId, Guid employeeId, bool trackChanges)
        {
            try
            {
                var employee = _repository.Employee.GetEmployeeById(projectId, employeeId, trackChanges);
                _logger.LogError("IEmployeeService.GetEmployeeById() has been run successfully!");

                return employee;
            }
            catch (Exception ex)
            {
                _logger.LogError("IEmployeeService.GetEmployeeById() has been crashed! " + ex.Message);
                throw;
            }
        }
    }
}
