using IdentityServer4.AccessTokenValidation;
using AnimalsFriends.Configuration;
using AnimalsFriends.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalsFriends
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>                    
                    builder.WithOrigins("http://localhost:3000")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
           
            var connectionString = this.Configuration.GetSection("ConnectionStrings").GetSection("AnimalsFriendsDB").Value;
            services.AddDbContext<AnimalsFriendsContext>(options => options.UseSqlServer(connectionString));           

            services.AddControllers()
            // Below JSON options are the default for ASP NET CORE 3.1
            // Written only for clarity. Can be safely removed as a whole.
            .AddJsonOptions(options =>
            {               
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.AllowTrailingCommas = false;
            });

            services.AddIdentityServer()
                .AddInMemoryApiResources(InMemoryConfig.GetApiResources())
                .AddInMemoryClients(InMemoryConfig.GetClients())
                .AddDeveloperSigningCredential();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
           // The method below also adds IHttpClientFactory to the service collection.
           // https://github.com/IdentityModel/IdentityModel.AspNetCore.OAuth2Introspection/blob/master/src/OAuth2IntrospectionExtensions.cs#L53
           .AddIdentityServerAuthentication(options =>
           {
               options.Authority = "https://localhost:44337/api/identity";
               options.ApiName = "AnimalsFriends";
               options.ApiSecret = "testSecret";
               options.SupportedTokens = SupportedTokens.Jwt;
               options.RequireHttpsMetadata = false;
               options.Validate();
           });

            services.AddHttpContextAccessor();

            DependencyConfig.Populate(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
                builder
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseHttpsRedirection();

            app.UseAuthentication();           

            app.Map("/api/identity", identityServerApp => identityServerApp.UseIdentityServer());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization();
            });
        }
    }
}
