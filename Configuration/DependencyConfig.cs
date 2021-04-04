using IdentityServer4.Validation;
using AnimalsFriends.Contracts.Repositories;
using AnimalsFriends.Contracts.Services;
using AnimalsFriends.Controllers;
using AnimalsFriends.Repositories;
using AnimalsFriends.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalsFriends.Configuration
{
    public class DependencyConfig
    {
        public static void Populate(IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);
            RegisterControllers(services);
        }

        private static void RegisterControllers(IServiceCollection services)
        {
            services.AddTransient(typeof(UserController));
            services.AddTransient(typeof(AnimalsController));
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IAnimalService), typeof(AnimalService));
            services.AddTransient(typeof(IResourceOwnerPasswordValidator), typeof(ResourceOwnerPasswordValidator));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IAnimalRepository), typeof(AnimalRepository));
        }
    }
}
