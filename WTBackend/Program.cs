using Microsoft.EntityFrameworkCore;
using WTBackend.Activity.ActivityRepo;
using WTBackend.Activity.InterfaceActivity;
using WTBackend.DbHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<KanbanDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IActivityRepo, ActivityRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger(); // Swagger aktivieren

    // Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kanban API v1");
        c.RoutePrefix = string.Empty; // Swagger UI unter / verfügbar
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
