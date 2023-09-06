using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ConsultationAppointment.Model;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("DbConn") ?? throw new InvalidOperationException("Connection string 'DbConn' not found.");
var connectionString = builder.Configuration.GetConnectionString("dbconn");
// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDbContext<ApiDbContext>(options =>
//    options.UseMySql(connectionString));

//builder.Services.AddDbContext<ApiDbContext>(options => options.UseMySql(builder.Configuration.GetSection("ConnectionStrings:dbconn").Value));


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:7243") // Adjust the origin(s) as needed
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
