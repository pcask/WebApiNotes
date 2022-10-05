using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges);
        Employee GetEmployeeById(Guid projectId, Guid employeeId, bool trackChanges);
    }
}
