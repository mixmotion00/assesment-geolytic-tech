using API.Mapper;
using API.Repositories;
using API.Validator;
using Application.Data;
using Application.Services;
using Domain.Interface;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// add services here
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<PropertyService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// fluent validation
builder.Services.AddValidatorsFromAssemblyContaining<CreateValuationValidator>();
builder.Services.AddFluentValidationAutoValidation();

// // Add services to the container.
// // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

var app = builder.Build();

// configure cors
app.UseCors(x =>
    x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("http://localhost:5173"));

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

Seeder.Seed();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
