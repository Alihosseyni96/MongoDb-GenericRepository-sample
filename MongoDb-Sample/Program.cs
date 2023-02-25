using Microsoft.Extensions.Configuration;
using MongoDb_Sample.Models;
using MongoDb_Sample.Repositories;
using MongoDb_Sample.Repositories.BaseRepository;
using MongoDb_Sample.Repositories.CustomerRepository;
using MongoDb_Sample.Repositories.ProducerRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var Nodes = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
var build = Nodes.Build();


builder.Services.Configure<DbConfiguration>(options => build.GetSection("MongoDbConnection").Bind(options));



builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();

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
