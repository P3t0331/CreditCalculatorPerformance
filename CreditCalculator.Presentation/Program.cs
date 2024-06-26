using CreditCalculator.After.Application;
using CreditCalculator.Storage;
using RegistR.Attributes.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InstallRegisterAttribute(typeof(CustomerService).Assembly);

////builder.Services.AddTransient<ICustomerDataProvider, JsonCustomerDataProvider>();
////builder.Services.AddTransient<ICustomerDataProvider, XmlCustomerDataProvider>();
builder.Services.AddTransient<ICustomerDataProvider, JsonSystemCustomerDataProvider>();

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
