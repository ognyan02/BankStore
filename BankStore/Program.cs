using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using BankStore.BL;
using BankStore.BL.Interfaces;
using BankStore.DL;
using BankStore.Models.Configurations;
using BankStore.Validators;
using BankStore.DL.Interfaces;
using BankStore.DL.Repositories.MongoDb;


namespace BankStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add configurations
            builder.Services.Configure<MongoDBConfiguration>(
                builder.Configuration
                .GetSection(nameof(MongoDBConfiguration)));


            //Add services to the container.
            builder.Services
                .RegisterRepositoies()
                .RegisterServices();

            builder.Services.AddMapster();

            builder.Services.AddControllers();

            builder.Services.AddValidatorsFromAssemblyContaining<TestValidator>();

            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddSwaggerGen();

            builder.Services.AddHealthChecks();

            var app = builder.Build();

            app.MapHealthChecks("/healthz");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}