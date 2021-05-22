using IdentityServer4.Validation;
using AnimalsFriends.Interfaces.Repositories;
using AnimalsFriends.Interfaces.Services;
using AnimalsFriends.Controllers;
using AnimalsFriends.Repositories;
using AnimalsFriends.Services;
using Microsoft.Extensions.DependencyInjection;
using PostsFriends.Repositories;

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
            services.AddTransient(typeof(PostsController));
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IAnimalService), typeof(AnimalService));
            services.AddTransient(typeof(IPostService), typeof(PostService));
            services.AddTransient(typeof(IResourceOwnerPasswordValidator), typeof(ResourceOwnerPasswordValidator));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IAnimalRepository), typeof(AnimalRepository));
            services.AddTransient(typeof(IPostRepository), typeof(PostRepository));
        }
    }
}
