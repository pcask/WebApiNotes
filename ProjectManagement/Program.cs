
using NLog;
using ProjectManagement.Extensions;

var builder = WebApplication.CreateBuilder(args);

// NLog configuration bilgilerinin oluşturduğumuz "nlog.config" dosyasından yükleneceğini bildiriyoruz.
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));


// Add services to the container.

// Aşağıda belirttiğimiz Assembly'den gelecek request'lerin de karşılanmasını sağlamak için AddApplicationPart method'ından yararlanıyoruz.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(ProjectManagement.Presentation.AssemblyReference).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Yazmış olduğumuz extension method'lar aracılığıyla gerekli configuration'ları builder'a ekliyoruz.
builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerManager();
builder.Services.ConfigureSqlConnection(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Services'lara eklemiş olduğumuz Cors Configurations' ları kullanacağımızı uygulamamıza belirtiyoruz.
app.UseCors("CorsPolicy");

app.Run();
