using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Solid.SqliteProvider;
using Solid.SqliteProvider.Interfaces;
using Solid.SqliteProvider.Interfaces.Implementation;
using System.Text.Json.Serialization;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SqliteContext>(o => o.UseSqlite($"Data Source={builder.Environment.ContentRootPath}\\DB\\packagesdb.db"));
builder.Services.AddScoped<IDataAccessProvider, DataAccessSqliteProvider>();

builder.Services.AddControllers().AddJsonOptions(option =>
        {
            option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
