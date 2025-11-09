using Domain.Abstractions;
using Domain.Abstractions.Works;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Works;
using Microsoft.Extensions.DependencyInjection;
using MyApplication;
using MyApplication.Abstractions;
using MyApplication.Abstractions.Works;
using MyApplication.Services;
using MyApplication.Services.Trees;
using MyApplication.Services.Works;

namespace Composition
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCoreServices(this IServiceCollection services)
        {
            // --- Repositories ---
            // Lifetime: Scoped is common for database contexts/repositories.
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IWorkCategoryRepository, WorkCategoryRepository>();
            services.AddScoped<IWorkTypeRepository, WorkTypeRepository>();
            services.AddScoped<IWorkSpecRepository, WorkSpecRepository>();
            services.AddSingleton<ICountryRepository, CountryRepository>();
            services.AddSingleton<ICityRepository, CityRepository>();
            services.AddScoped<IWorkCategoryDesignationRepository, WorkCategoryDesignationRepository>();
            // ... add all other repositories

            // --- Services ---
            // Lifetime: Scoped is common for services tied to a user session/request.
            services.AddScoped<IWorkCategoryDesignationService, WorkCategoryDesignationService>();
            services.AddScoped<IWorkSpecService, WorkSpecService>();
            services.AddScoped<IWorkTypeService, WorkTypeService>();
            services.AddScoped<IWorkCategoryService, WorkCategoryService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddSingleton<ICountryService, CountryService>();
            services.AddSingleton<ICityService, CityService>();

            services.AddScoped<IProjectTreeService, ProjectTreeService>();
            // ... add all other services (the container resolves their dependencies automatically)

            return services;
        }
    }
}
