using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;
using System.Reflection;
using Microsoft.CodeAnalysis.Operations;
using DefaultWebApplication.Attributes;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using DefaultWebApplication.Models.Setting_Models;
using Microsoft.EntityFrameworkCore;
using DefaultWebApplication.Database;

namespace DefaultWebApplication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(
            this IServiceCollection services)
        {
            var currentExecutingAssembly = Assembly.GetExecutingAssembly();

            foreach (Type type in currentExecutingAssembly.GetTypes())
            {
                var customServiceAtt = (CustomServiceAttribute)type.GetCustomAttribute(typeof(CustomServiceAttribute));

                if (customServiceAtt != null)
                {
                    if (customServiceAtt.Lifetime == ServiceLifetime.Transient)
                    {
                        services.AddTransient(type);
                    }
                    else if (customServiceAtt.Lifetime == ServiceLifetime.Scoped)
                    {
                        services.AddScoped(type);
                    }
                    else if (customServiceAtt.Lifetime == ServiceLifetime.Singleton)
                    {
                        services.AddSingleton(type);
                    }
                    else
                    {
                        throw new ArgumentException($"Invalid lifetime selected for the service:{nameof(type)}.");
                    }
                }
            }
        }

        public static void BindSection<TSetting>(
            this IServiceCollection services,
            IConfiguration configuration,
            string sectionName) where TSetting : class, new()
        {
            var settingInstance = new TSetting();
            configuration.GetSection(sectionName).Bind(settingInstance);
            services.AddSingleton(settingInstance);
        }

        public static void BindSection<TSetting>(
            this IServiceCollection services,
            IConfiguration configuration) where TSetting: class, new()
        {
            var settingInstance = new TSetting();
            configuration.GetSection(settingInstance.GetType().Name).Bind(settingInstance);
            services.AddSingleton(settingInstance);
        } 

        public static void AddDatabaseContext<TSetting>(
            this IServiceCollection services) where TSetting : DefaultDatabaseSettings, new()
        {
            var settings = new TSetting();
            var _connString = settings.ConnectionString;
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(_connString);
            });
        }
    }
}
