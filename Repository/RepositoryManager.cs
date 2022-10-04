using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        private readonly ProjectRepository _projectRepository;
        private readonly EmployeeRepository _employeeRepository;

        public RepositoryManager(RepositoryContext context, ProjectRepository projectRepository, EmployeeRepository employeeRepository)
        {
            _context = context;
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
        }

        public IProjectRepository Project => _projectRepository;
        public IEmployeeRepository Employee => _employeeRepository;

        public void Save() => _context.SaveChanges();
        
    }
}
