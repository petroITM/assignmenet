using Assignment;
using Assignment.Dto;
using Assignment.Services;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddDbContext<ContactDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ContactSqlDb")));

builder.Services.AddScoped<IValidator<AddContactDto>, AddContactDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateContactDto>, UpdateContactDtoValidator>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseExceptionHandler(

    //It can be developed and build in a better way (custom exception types, mapping to certain http status codes
    //Because of lack of time, it stays as below
  builder =>
  {
      builder.Run(
        async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "text/html";

            var error = context.Features.Get<IExceptionHandlerFeature>();
            if (error != null)
            {
                await context.Response.WriteAsync($"<h1>Error: {error.Error.Message}</h1>").ConfigureAwait(false);
            }
        });
  });

app.Run();
