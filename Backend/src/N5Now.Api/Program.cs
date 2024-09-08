using FluentValidation;
using System.Reflection;
using Microsoft.OpenApi.Models;
using N5Now.Api.Middlewares;
using FluentValidation.AspNetCore;
using N5Now.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using N5Now.Infrastructure.ExtensionMethods.DI;
using N5Now.Application.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load));

builder.Services.AddDbContext<N5NowContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("N5NowContext")));

builder.Services.SetupUnitOfWork();
builder.Services.SetupBuisnessServices();
builder.Services.SetupServices(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load));

var client = builder.Configuration.GetSection("ClientHost").Value;

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
       _ => _
        .WithOrigins(builder.Configuration.GetSection("ClientHost").Value)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
      );
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "N5Now.API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "N5Now.API v1"));
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

// Use Exception Middleware
app.UseMiddleware<ExceptionHandler>();

app.UseAuthorization();

app.MapControllers();

app.Run();
