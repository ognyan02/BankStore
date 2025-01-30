using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using BankStore.BL;
using BankStore.BL.Interfaces;
using BankStore.DL;
using BankStore.Models.Configurations;
using BankStore.Validators;

namespace BankStore
{

public class Program
    {   public static void Main(string[] args)
        {
            var bilder = WebApplication.CreateBuilder(args);
            //Add configuration
            bilder.Services.Configure<MongoDBConfiguration>(
                bilder.Configuration
                .GetSection(nameof(MongoDBConfiguration)));
            //Add service to the container
            bilder.Services
                .RegisterRepositoies()
                .RegisterServices();
            bilder.Services.AddMapster();

            bilder.Services.AddControllers();

            bilder.Services.AddValidatorsFromAssemblyContaining<TestValidator>();

            bilder.Services.AddFluentValidationAutoValidation();

            bilder.Services.AddSwaggerGen();

            bilder.Services.AddHealthChecks();

            var app = bilder.Build();
            app.MapHealthChecks("/healthz");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //Configure the HTTP request pipeline

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
       
    }

}