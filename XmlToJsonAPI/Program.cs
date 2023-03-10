using XmlToJsonAPI.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using XmlToJsonAPI.DAL.Repositories.Interfaces;
using XmlToJsonAPI.Services.Interfaces;
using XmlToJsonAPI.Services.Implementations;
using XmlToJsonAPI.DAL.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IXmlRepository, XmlRepository>();

builder.Services.AddTransient<IXmlTemplateService, XmlTemplateService>();


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
