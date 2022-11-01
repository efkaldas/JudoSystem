using DbUp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JudoSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using JudoSystem.Services;
using Entities;
using Contracts.Interfaces;
using Repository;
using LoggerService;
using ActionFilters.Filters;
using Entities.Models;
using JudoSystem.Interfaces;

namespace JudoSystem.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, string myAllowSpecificOrigins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(myAllowSpecificOrigins,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }
        public static void ConfigureMySql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JudoDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("JudoSystem-db"), ServerVersion.AutoDetect(configuration.GetConnectionString("JudoSystem-db"))));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
        public static void InitilizeObjects(this IServiceCollection services)
        {
            services.AddScoped<IEmailSendService, EmailSendService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IAuthService, AuthService>();
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JudoSystem API", Version = "v1" });
            });
        }
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JWT:ValidIssuer"],
                        ValidAudience = configuration["JWT:ValidAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"]))
                    };
                });
        }
        public static void ConfigureFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidateEntityExists<User>>();
            services.AddScoped<ValidateForm>();
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
        public static void ConfigureDapper(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("JudoSystem-db");

            DataAccess DataAccess = new DataAccess(connectionString);

            var upgrader = DeployChanges.To
                .MySqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();
            
        }
    }
}
