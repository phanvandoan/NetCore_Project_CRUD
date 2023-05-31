using Microsoft.EntityFrameworkCore;
using NetCore_Project.Middleware;
using NetCore_Project.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//đăng ký connectstring
builder.Services.AddDbContext<ExampleDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//dang ky collect interface
builder.Services.RegisterIoCs(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
