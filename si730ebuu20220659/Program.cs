
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using si730ebuu20220659.Inventory.Application.Internal.CommandService;
using si730ebuu20220659.Inventory.Application.Internal.QueryService;
using si730ebuu20220659.Inventory.Domain.Repository;
using si730ebuu20220659.Inventory.Domain.Service;
using si730ebuu20220659.Inventory.Infrastructure.Persistance.EFC.Repositories;
using si730ebuu20220659.Shared.Domain.Repositories;
using si730ebuu20220659.Shared.Infrastructure.Interfaces.ASP.Configuration;
using si730ebuu20220659.Shared.Infrastructure.Interfaces.Middleware;
using si730ebuu20220659.Shared.Infrastructure.Persistance.EFC.Configuration;
using si730ebuu20220659.Shared.Infrastructure.Persistance.EFC.Repositories.BaseRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = " IRRIOT API",
                Version = "v1",
                Description = " IRRIOT  Platform API",
                TermsOfService = new Uri("https://IRRIOT.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "Gabriel Mamani Marca 202220659",
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// // Catalogue Bounded Context Injection Configuration

builder.Services.AddScoped<IThingRepository, ThingRepositoryImpl>();
builder.Services.AddScoped<IThingCommandService, ThingCommandServiceImpl>();
builder.Services.AddScoped<IThingQueryService, ThingQueryServiceImpl>();

// builder.Services.AddScoped<IContractRepository, ContractRepositoryImpl>();
// builder.Services.AddScoped<IContractCommandService, ContractCommandServiceImpl>();


var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// For exception handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();