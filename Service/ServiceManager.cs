using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProjectService _projectService;
        private readonly IEmployeeService _employeeService;

        public ServiceManager(IProjectService projectService, IEmployeeService employeeService)
        {
            _projectService = projectService;
            _employeeService = employeeService;
        }

        public IProjectService ProjectService => _projectService;

        public IEmployeeService EmployeeService => _employeeService;
    }
}
