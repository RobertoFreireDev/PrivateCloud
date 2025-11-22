var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

ApiConfig.CustomDb = builder.Configuration.GetConnectionString("CustomDb");
ApiConfig.SystemDb = builder.Configuration.GetConnectionString("SystemDb");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(ApiConfig.SystemDb);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
