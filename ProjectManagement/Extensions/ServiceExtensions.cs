﻿using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                    .AllowAnyOrigin()   // Api'a başvuru yapan bütün origin'lere,
                    .AllowAnyMethod()   // bütün method'lara
                    .AllowAnyHeader()  // bütün http header'lara izin ver, demiş oluyoruz.
                    .WithOrigins("www.google.com", "www.youtube.com")   // Veya sadece erişimine izin vermek istediğimiz origins, methods, headers' ları belirtebiliriz.
                    .WithMethods("get");
                });
            });
        }
        public static void ConfigureLoggerManager(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerManager>();
        }
        public static void ConfigureSqlConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                optionsBuilder => optionsBuilder.MigrationsAssembly("ProjectManagement")) // Migration dosyalarının hangi assembly de oluşacağını belirtiyoruz.
            );
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>()
                .AddScoped(typeof(ProjectRepository))
                .AddScoped(typeof(EmployeeRepository));

        // Singleton => Uygulama çalışmaya başladığında gerekli nesnelerin instance'ı oluşturulur ve uygulama sonlanana kadar bu instance kulanılır.
        // Scoped    => Request gönderildikten sonra gerekli nesnelerin instance'ı oluşturulur ve request sonlanana kadar bu instance kulanılır.
        // Transient => Gerekli nesneler için her zaman yeni bir nesne oluşturulur.

    }
}
