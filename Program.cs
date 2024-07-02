using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MigrationService.Data;
using MigrationService.Interfaces;
using MigrationService.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner.
builder.Services.AddControllers();

// Verifique se o ambiente é de desenvolvimento ou de testes para usar o banco de dados em memória
if (builder.Environment.IsDevelopment() || builder.Environment.EnvironmentName == "Testing")
{
    builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseInMemoryDatabase("TestDatabase"));
}
else
{
    // Use uma string de conexão válida apenas em produção ou em outros ambientes configurados
    builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}

builder.Services.AddScoped<IProcedureRepository, ProcedureRepository>();
builder.Services.AddScoped<IProcessService, ProcessService>();
builder.Services.AddScoped<IExtractionService, ExtractionService>();
builder.Services.AddScoped<ISiglaService, SiglaService>();


// Adicione e configure o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MigrationService API",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MigrationService API V1");
    });
}

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DatabaseContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
