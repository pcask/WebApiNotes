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
    }
}
