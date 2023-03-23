using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using PockOData.Api.Domain.Entities;
using PockOData.Api.Domain.Interfaces;
using PockOData.Api.Infra.Context;
using PockOData.Api.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
var modelBuilder = new ODataConventionModelBuilder();

modelBuilder.EntitySet<School>("School");
modelBuilder.EntitySet<Student>("Student");
modelBuilder.EntitySet<ClassRoom>("ClassRoom");
modelBuilder.EntitySet<Teacher>("Teacher");

builder.Services.AddControllers().AddOData(
    options => options
        .Select()
        .Filter()
        .OrderBy()
        .Expand()
        .Count()
        .SetMaxTop(null)
        .EnableQueryFeatures()
        .AddRouteComponents(
            "odata",
            modelBuilder.GetEdmModel())
        );

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var _connectionString = builder.Configuration.GetConnectionString("MySqlConnectionString");
builder.Services.AddDbContext<DataContext>(x => x.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString)));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
