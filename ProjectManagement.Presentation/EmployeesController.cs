using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Presentation
{
    [ApiController]
    [Route("api/projects/{projectId}/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllEmployeesByProjectId(Guid projectId)
        {
            var employees = _service.EmployeeService.GetAllEmployeesByProjectId(projectId, false);

            return Ok(employees);
        }

        [HttpGet("{employeeId:guid}")]
        public IActionResult GetEmployeeById(Guid projectId, Guid employeeId)
        {
            var employee = _service.EmployeeService.GetEmployeeById(projectId, employeeId, false);

            return Ok(employee);
        }
    }
}
