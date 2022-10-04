using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Config
{
    // Fluent API yaklaşımı her entity'e özel olacak şekilde ele alabilmek için IEntityTypeConfiguration interface'ini kullanabiliriz.
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            // Database'in, varsa seed data'lar ile birlikte oluşturulması için;
            builder.HasData(new Project
            {
                Id = new Guid("79D72FB7-9EE9-4EF0-A87A-AD4661848D9D"),
                Name = "ASP.NET Core Web API Project",
                Description = "ASP.NET Core Web API Project on Onion Architecture.",
                Field = "Computer Science"
            },
            new Project
            {
                Id = new Guid("404DE5B9-3246-40BB-847C-952313521EE2"),
                Name = "Save The World",
                Description = "An app that aims to raise public awareness about carbon footprint.",
                Field = "Global Warming"
            });
        }
    }
}
