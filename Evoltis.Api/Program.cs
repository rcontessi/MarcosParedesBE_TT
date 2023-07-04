using Evoltis.IoC;
using Evoltis.Middleware;
using Evoltis.Middleware.Filter;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;


// Add services to the container.

builder.Services.AddControllers()
    .AddMvcOptions(options =>
    {
        options.Filters.Add(new ValidateModelAttribute());
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependencies
builder.Services.AddEvoltisDependencies(configuration);

//Cors
builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Cors
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

