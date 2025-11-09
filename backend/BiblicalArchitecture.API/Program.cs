using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BiblicalArchitecture.Infrastructure.Data;
using BiblicalArchitecture.API.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    });

// Configuração do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Biblical Architecture API", Version = "v1" });
});

// Configuração da injeção de dependência
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configurar o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Biblical Architecture API v1"));

    // Aplicar migrações e popular dados iniciais em desenvolvimento
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            
            // Aqui você pode adicionar a lógica para popular dados iniciais
            // Exemplo: await SeedData.Initialize(services);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Ocorreu um erro ao popular o banco de dados.");
        }
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Inicializar o banco de dados com dados iniciais
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        await ModuloSeedData.Initialize(services);
        loggerFactory.CreateLogger<Program>().LogInformation("Dados iniciais carregados com sucesso!");
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Ocorreu um erro ao popular o banco de dados");
    }
}

app.Run();
