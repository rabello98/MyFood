﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFood.Framework.Attribures;
using MyFood.Framework.Context;
using MyFood.Framework.Contracts.Context;
using MyFood.Framework.Contracts.DAO;
using MyFood.Framework.DAO;
using MyFood.Model;
using MyFood.ViewModel;
using SimpleInjector;
using System;
using System.Linq;
using System.Reflection;
using MyFood.Framework.Extensions;
using MyFood.Framework.Contracts.Service;
using MyFood.Service;

namespace MyFood.Framework.AppStart
{
    public static class SimpleInjectorInit
    {
        public static IConfiguration Configuration { get; private set; }
        public static void Initialize(Container container, IServiceCollection services, IConfiguration configuration)
        {
            Configuration = configuration;

            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation();
            });

            services.AddDbContext<MyFoodContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            InitializeContainer(container);
            ConfigAutoMapper(container);
        }

        private static void InitializeContainer(Container container)
        {
            container.Register(typeof(IRepository<>), typeof(BaseRepository<>), Lifestyle.Scoped);
            container.Register<ICreditCardValidatorService, CreditCardValidatorService>(Lifestyle.Scoped);

            var resolver = new DependencyInjectionFacade(container);
            container.RegisterInstance<IDependencyInjectionFacade>(resolver);

            var appContext = new MyFoodAppContext(Configuration, resolver);
            container.RegisterInstance<IMyFoodAppContext>(appContext);
        }

        private static void ConfigAutoMapper(Container container)
        {
            var config = new MapperConfiguration(cfg =>
            {
                InitializeAutoMapper(cfg);
            });
            config.AssertConfigurationIsValid();

            var mapper = new Mapper(config, container.GetInstance);

            container.RegisterInstance<IMapper>(mapper);
        }

        private static void InitializeAutoMapper(IMapperConfigurationExpression cfg)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes().Where(t => t.GetCustomAttribute<MapToAttribute>() != null);

            foreach (var type in types)
            {
                var mapAttribute = type.GetCustomAttribute<MapToAttribute>();
                cfg.CreateMap(type, mapAttribute.Type).IgnoreMaps(type, mapAttribute.Type);
                cfg.CreateMap(mapAttribute.Type, type);
            }
        }
    }
}
