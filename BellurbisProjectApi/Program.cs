using Microsoft.EntityFrameworkCore;
using BellurbisProjectApi.Repository;
using BellurbisProjectApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DBContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));

builder.Services.AddScoped<RPRepository, RPRepository>();
builder.Services.AddControllers();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapControllers();

app.Run();
