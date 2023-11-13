using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Infrastructure;
using System.Net.NetworkInformation;
using System.Reflection;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureDI();
builder.Services.AddApplicationDI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(
             options =>
             {
                 options.Run(
                     async context =>
                     {
                         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                         context.Response.ContentType = "text/html";
                         var ex = context.Features.Get<IExceptionHandlerFeature>();
                         if (ex != null)
                         {
                             var err = $"<h3>Error: {ex.Error.Message}</h3>{ex.Error.StackTrace}";
                             await context.Response.WriteAsync(err).ConfigureAwait(false);
                         }
                         //тут можно использовать какой нибудь логер, просто выдал ответом
                     });
             }
         );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
