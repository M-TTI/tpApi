using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using tpApi.Data;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers()
    .AddJsonOptions(options => // Pour pouvoir post un forecast avec city ou City ou encore CITY et que tout fonctionne avec les enums
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Forecast API",
        Version = "v1",
        Description = "J'essaie de génerer une doc"
    });
});



var app = builder.Build();

// Create db if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Forecast API v1");
        options.RoutePrefix = string.Empty;
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();