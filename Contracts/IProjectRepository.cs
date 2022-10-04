using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects(bool trackChanges);
        Project GetProject(Guid id, bool trackChanges);

        // Şuan Update için method imzasına ihtiyaç duymadık çünkü üst satırda projeyi ele alırken "trackChanges" değişkeni vasıtasıyla 
        // değişiklikleri takipedebilir ve bunları database'e yansıtabiliriz.
        void CreateProject(Project project);
        void DeleteProject(Project project);
    }
}
