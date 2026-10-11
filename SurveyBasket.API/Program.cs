using Microsoft.Extensions.DependencyInjection;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();  //****** Swagger
builder.Services.AddSwaggerGen();    //****** Swagger

builder.Services.AddScoped<IPollServices, PollServices>(); // **

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   //****** Swagger

    app.UseSwaggerUI(options =>    //****** Swagger
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "SurveyBasket API V1"
        );
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();