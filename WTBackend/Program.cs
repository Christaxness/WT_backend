using Microsoft.EntityFrameworkCore;
using WTBackend.Activity.ActivityRepo;
using WTBackend.Activity.InterfaceActivity;
using WTBackend.Column.Interface;
using WTBackend.Column.Repository;
using WTBackend.DbHelper;
using WTBackend.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Holen des Connection Strings aus der Umgebungsvariable (über Render gesetzt) oder fallback auf `appsettings.json`
string dbConnectionString = builder.Configuration.GetValue<string>("DB_CONNECTION_STRING") ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<KanbanDbContext>(option =>
    option.UseNpgsql(dbConnectionString));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IActivityRepo, ActivityRepository>();
builder.Services.AddScoped<IColumnRepo, ColumnRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<KanbanDbContext>();
    dbContext.Database.Migrate();
    KanbanDbContext.Seed(dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kanban API v1");
        c.RoutePrefix = string.Empty;
    });

    // HTTPS-Redirection NUR in Development
    app.UseHttpsRedirection();
}

app.UseCors("AllowAll");

// WICHTIG: Keine HTTPS-Redirection in Production!
// Die folgende Zeile wurde entfernt:
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
