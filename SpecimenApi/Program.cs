using Application.Specimen.Query.GetManifests;
using Domain.ExceptionHandling;
using Infrastructure.Context;
using Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Specimen API",
        Version = "v1",
        Description = "API for specimen management"
    });
});
builder.Services.AddMediatR(cfs => cfs.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<DbRepository>();
builder.Services.AddMediatR(cfs => cfs.RegisterServicesFromAssembly(typeof(GetManifestsActionHandler).Assembly));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("SpecimenApi") // force migrations here
    ));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueDevClient",
        policy => policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});
var app = builder.Build();

// Enable Swagger middleware in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Specimen API v1");
        c.RoutePrefix = string.Empty; // Swagger UI at root
    });
}
app.UseCors("AllowVueDevClient");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
