using CheckSkillsASP.Data;
using CheckSkillsASP.Interfaces;
using CheckSkillsASP.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

//Logging with Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.MapControllers();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

//try
//{

//}
//catch(Exception ex)
//{
//    var logger = services.GetService<ILogger<Program>>();
//    logger.LogError(ex, "Error While Connecting To Database");
//}

app.Run();
