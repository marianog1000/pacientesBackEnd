using Microsoft.EntityFrameworkCore;
using medical_health_history.Data;
using medical_health_history.Repositories;
using Pacientes.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",

             policy =>
             {
                 policy.WithOrigins("http://localhost:3000", 
                                    "https://67afc5580f57c8a4225b5621--glittering-yeot-761ccf.netlify.app")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
             });
});


builder.Services.AddDbContext<HealthHistoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<HealthHistoryRepository>();
builder.Services.AddScoped<HealthHistoryService>();
builder.Services.AddScoped<UserCredentialRepository>();
builder.Services.AddScoped<UserCredentialService>();
builder.Services.AddScoped<HealthHistoryChangeService>();
builder.Services.AddScoped<HealthHistoryChangeRepository>();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});


app.Run();
