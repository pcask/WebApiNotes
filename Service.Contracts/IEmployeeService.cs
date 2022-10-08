using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges);
        EmployeeDto GetEmployeeById(Guid projectId, Guid employeeId, bool trackChanges);
        EmployeeDto CreateOneEmployee(Guid projectId, EmployeeDtoForCreation eDtoFC);
    }
}
