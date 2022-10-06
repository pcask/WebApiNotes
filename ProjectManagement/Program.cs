
using Contracts;
using NLog;
using ProjectManagement.Extensions;
using System.Reflection;

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

// Belirtilen Assembly içerisindeki bütün 'Profile' türündeki nesneleri bulur ve mapping işlemleri için bu Profile'ları baz alır. 
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


// Server ile client arasındaki ilk başarılı Https bağlantısından sonra response içerisindeki header'da client'ın
// (browser'ın) Hsts Policy doğrultusunda uyması gereken kurallar yer alacaktır.
// Bu Hsts Policy sayesinde client'ın browser'ı eğer ki bu politikayı destekliyorsa, uygulamamıza bütün isteklerinin Https üzerinden yapılması sağlanır.
// Kısaca kullanıcı tarayıcısında bir hatırlatıcı bırakıyoruz ve benim uygulamama tekrar istek yaptığında hatırlatıcı okunarak Http istekleri
// yönlendirilmeden direk https olarak gönderilecektir.
builder.Services.AddHsts(options =>
{
    // Uygulamamızın, client'ın (browser'ın) Hsts Policy Ön Yükleme listesine dahil edilmek üzere alan adlarını göndermek için kullanılır.
    options.Preload = true;
    options.IncludeSubDomains = true;       // Hsts Policy' nin subdomainler içinde gereçli kılınması isteği.
    options.MaxAge = TimeSpan.FromDays(60); // Clinet'da (kullanıcı browser'ında) Hsts Policy doğrultusunda gelen header verilerilerinin cache süresi 
    
    // İstersek bazı sub domainlerimizde Hsts politikasının uygulanmamasını isteyebiliriz.
    options.ExcludedHosts.Add("example.com");
    options.ExcludedHosts.Add("www.example.com");
});

var app = builder.Build();

// Exception Handler için yazmış olduğumuz extention method aracılığıyla gerekli configuration'ları app'e ekliyoruz.
// Extention method'ımız bizden somut bir logger nesnesi istiyor bunun için de app.Services.GetRequiredService method'ından yararlanıyoruz.
app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILoggerService>());


if(app.Environment.IsProduction()) // Eğer ürünümüz production ortamındaysa;
    app.UseHsts(); // Hsts Policy'nin productionda aktif edilmesi uygun olacaktır, aksi halde development aşamasında gereksiz cache'lemeer oluşacaktır. 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Client'dan gelen tüm Http isteklerini Https protokolüne yeniden yönlendirir ve güvenli bağlantı sağlar.

app.UseAuthorization();

app.MapControllers();

// Services'lara eklemiş olduğumuz Cors Configurations' ları kullanacağımızı uygulamamıza belirtiyoruz.
app.UseCors("CorsPolicy");

app.Run();
