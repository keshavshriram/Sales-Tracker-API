using Microsoft.EntityFrameworkCore;
using Sales_Tracking.API.Data;
using Sales_Tracking.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<FormMangmentService>();
builder.Services.AddScoped<MaterialManagementService>();
builder.Services.AddDbContext<TrackerDBContext>(option =>
        option.UseSqlServer(builder.Configuration.GetConnectionString("TrackerConnectionString"))
);

builder.Services.AddCors(option =>
    option.AddPolicy("AllowedOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        }
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowedOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
