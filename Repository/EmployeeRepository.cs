using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeForProject(Guid projectId, Employee employee)
        {
            employee.ProjectId = projectId;
            Create(employee);
        }
        public void DeleteEmployee(Employee employee) => Delete(employee);

        public IEnumerable<Employee> GetAllEmployeesByProjectId(Guid projectId, bool trackChanges) =>
            FindByCondition(e => e.ProjectId == projectId, trackChanges)
            .OrderBy(e => e.FirstName)
            .ToList();

        public Employee GetEmployeeById(Guid projectId, Guid employeeId, bool trackChanges) =>
            FindByCondition(e => e.ProjectId == projectId && e.Id == employeeId, trackChanges)
            .FirstOrDefault();
    }
}
