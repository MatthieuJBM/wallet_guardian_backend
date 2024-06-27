using Microsoft.EntityFrameworkCore;
using Serilog;
using wallet_guardian_backend.Configurations;
using wallet_guardian_backend.Contracts;
using wallet_guardian_backend.Data;
using wallet_guardian_backend.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ConnectionString added
var connectionString = builder.Configuration.GetConnectionString("WalletGuardianDbConnectionString");
// DBContext added
builder.Services.AddDbContext<WalletGuardianDbContext>(options => { options.UseMySQL(connectionString); });
// Controllers added
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors added
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());
});

// Serilog added
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

// AutoMapper added
builder.Services.AddAutoMapper(typeof(MapperConfig));

// Repositories added
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
// builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<ISubcategoriesRepository, SubcategoriesRepository>();
builder.Services.AddScoped<IKategoriesRepository, KategoriesRepository>();
builder.Services.AddScoped<IShopsRepository, ShopsRepository>();
builder.Services.AddScoped<IPurchasesRepository, PurchasesRepository>();
builder.Services.AddScoped<IMonthlyBudgetStatisticsRepository, MonthlyBudgetStatisticsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}