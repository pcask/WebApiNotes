using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges);
        Employee GetEmployeeByProjectId(Guid projectId, int employeeId, bool trackChanges);

        void CreateEmployeeForProject(Guid projectId, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
