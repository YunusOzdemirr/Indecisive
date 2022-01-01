using Services.AutoMapper.Profiles;
using Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
builder.Services.LoadMyServices();
builder.Services.AddAutoMapper(typeof(CategoryProfile), typeof(CompanyProfile));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

