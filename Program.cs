using DbFirstCIS2.DATA;
using DbFirstCIS2.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IComputerDetailsRepository, ComputerDetailsRepository>();
builder.Services.AddScoped<IStatusComputerDetailsRepository, StatusComputerDetailsRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContinousIntegrationScriptDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options => options.AddPolicy(name: "demo",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("demo");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
