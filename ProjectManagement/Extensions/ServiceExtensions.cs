using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Utilities.OutPutFormatters;
using Repository;
using Service;
using Service.Contracts;

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

        // Singleton => Uygulama çalışmaya başladığında gerekli nesnelerin instance'ı oluşturulur ve uygulama sonlanana kadar bu instance kulanılır.
        // Scoped    => Request gönderildikten sonra gerekli nesnelerin instance'ı oluşturulur ve request sonlanana kadar bu instance kulanılır.
        // Transient => Gerekli nesneler için her zaman yeni bir nesne oluşturulur.
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
            services.AddScoped<IRepositoryService, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>()
                    .AddScoped<IProjectService, ProjectManager>()
                    .AddScoped<IEmployeeService, EmployeeManager>();

        public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(option => option.OutputFormatters.Add(new CsvOutputFormatter()));
    }
}
