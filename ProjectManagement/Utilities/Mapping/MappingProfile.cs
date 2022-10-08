using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Utilities.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<ProjectDtoForCreation, Project>();
            CreateMap<EmployeeDtoForCreation, Employee>();
        }
    }
}
