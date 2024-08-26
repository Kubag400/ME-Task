using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using Server.Services;
using Server.Validators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "_allowAll";
// Add services to the container.
ValidatorOptions.Global.LanguageManager.Enabled = false;
builder.Services.AddScoped<IProductService, ProductInMemoryService>();
builder.Services.AddScoped<IValidator<ProductRequest>, ProductRequestValidator>();
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<ApiDbContext>(opt =>
{
    opt.UseInMemoryDatabase(builder.Configuration.GetConnectionString("Database"));
});
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: corsPolicy, policy => {
        policy.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddHostedService<DatabaseFixture>();
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

app.UseCors(corsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();
