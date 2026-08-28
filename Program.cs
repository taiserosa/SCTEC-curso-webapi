using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI( options =>
{
   options.SwaggerEndpoint("/openapi/v1.json", "API v1"); 
});

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.MapGet("/banana", () => "Você chamou o método Banana!");

app.Run();