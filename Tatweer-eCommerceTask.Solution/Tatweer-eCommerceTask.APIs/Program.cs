using Microsoft.EntityFrameworkCore;
using Tatweer_eCommerceTask.APIs.Middlewares;
using Tatweer_eCommerceTask.Core.Repositories.Contract;
using Tatweer_eCommerceTask.Repository;
using Tatweer_eCommerceTask.Repository.Data;

var builder = WebApplication.CreateBuilder(args);
#region Configure Services

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

#endregion

var app = builder.Build();

#region Update Database On Each Program Run instead of using EFCore(Update Database)

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

var _dbContext = services.GetRequiredService<StoreContext>(); //Ask CLR to create object from DbContext Explicitly

var loggerFactory = services.GetRequiredService<ILoggerFactory>();

try
{
    await _dbContext.Database.MigrateAsync();  // Update-Database
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "an error happened during applying the migration");
}

#endregion

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


app.UseAuthorization();

app.MapControllers();

app.Run();
