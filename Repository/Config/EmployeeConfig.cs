using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(new Employee
            {
                Id = new Guid("359F7F82-6A5A-455E-B672-4DAA82A92202"),
                FirstName = "Sezer",
                LastName = "Ayran",
                DateOfBirth = new DateTime(1992, 05, 11),
                Position = "Sofware Developer",
                ProjectId = new Guid("404DE5B9-3246-40BB-847C-952313521EE2")
            });
        }
    }
}
