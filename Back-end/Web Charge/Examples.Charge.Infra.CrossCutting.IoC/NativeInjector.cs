using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Examples.Charge.Application.AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Facade;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Repositories;

namespace Examples.Charge.Infra.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void Setup(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterAutoMapper(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ExampleDto>();

            services.AddScoped<IExampleFacade, ExampleFacade>();
            services.AddScoped<IExampleService, ExampleService>();
            services.AddScoped<IExampleRepository, ExampleRepository>();

            services.AddScoped<IPersonFacade, PersonFacade>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<IPersonPhoneService, PersonPhoneService>();
            services.AddScoped<IPersonPhoneRepository, PersonPhoneRepository>();
            
            services.AddScoped<IPhoneNumberTypeService, PhoneNumberTypeService>();
            services.AddScoped<IPhoneNumberTypeRepository, PhoneNumberTypeRepository>();
        }

        private static void RegisterAutoMapper(IServiceCollection services)
        {
            new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<ExampleProfile>();
            }).CompileMappings();
        }
    }
}
