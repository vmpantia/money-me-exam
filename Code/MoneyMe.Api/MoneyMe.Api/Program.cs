using Microsoft.EntityFrameworkCore;
using MoneyMe.Api.Contractors;
using MoneyMe.Api.DataAccess;
using MoneyMe.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MoneyMeDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("con")));

builder.Services.AddScoped<IQuotationService, QuotationService>();

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
