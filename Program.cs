using Microsoft.AspNetCore.Builder;
using Trasnlator.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add your custom services with configuration
builder.Services.AddServiceCollectionsExtensions(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.MapOpenApi(); // Only if you're specifically using this middleware
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();