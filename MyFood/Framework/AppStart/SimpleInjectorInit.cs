using AutoMapper;
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
                cfg.CreateMap(type, mapAttribute.Type);
                cfg.CreateMap(mapAttribute.Type, type);
            }

            // Automapper is lost here ¯\_(ツ)_/¯
            cfg.CreateMap<PedidoProdutoView, PedidoProduto>()
                .ForMember(m => m.Pedido, opt => opt.MapFrom(s => s.PedidoView))
                .ForMember(m => m.Produto, opt => opt.MapFrom(s => s.ProdutoView));
            cfg.CreateMap<PedidoProduto, PedidoProdutoView> ()
                .ForMember(m => m.PedidoView, opt => opt.MapFrom(s => s.Pedido))
                .ForMember(m => m.ProdutoView, opt => opt.MapFrom(s => s.Produto));
        }
    }
}
