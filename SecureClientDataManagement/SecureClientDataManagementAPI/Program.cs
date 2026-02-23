using Microsoft.OpenApi.Models;
using SecureCientDataManagementAPI.Interfaces;
using SecureCientDataManagementAPI.Repositories;
using SecureCientDataManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()    
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// Add services to the container.
builder.Services.AddControllers();

// Swagger + OpenAPI full setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "SecureClientDataManagementAPI", Version = "v1" });
});
// Dependencies
builder.Services.AddSingleton<IEncryptionService, EncryptionService>();
builder.Services.AddSingleton<IClientRepository, InMemoryClientRepository>();
builder.Services.AddSingleton<IClientService, ClientService>();
builder.WebHost.UseUrls("http://0.0.0.0:80");
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;   // ← yeh line add kar do (root pe Swagger khulega)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();