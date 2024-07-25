using CustomerSatisfaction.Core;
using CustomerSatisfaction.MLModels;
using CustomerSatisfaction.Repositories;
using CustomerSatisfaction.Services;
using Microsoft.ML;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MLContext>(); // Singleton because MLContext is thread-safe and should be reused
builder.Services.AddScoped<CustomerSatisfactionModel>(); // Scoped or Singleton depending on how you want to use it
builder.Services.AddScoped<CustomerReviewService>();

// Configure repositories
builder.Services.AddScoped<ICustomerReviewRepository, CustomerReviewRepository>();

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
