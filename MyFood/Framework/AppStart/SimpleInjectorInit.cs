using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFood.Framework.Context;
using MyFood.Framework.Contracts.Context;
using MyFood.Framework.Contracts.DAO;
using MyFood.Framework.DAO;
using MyFood.Model;
using MyFood.ViewModel;
using SimpleInjector;

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
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioView, Usuario>();
                cfg.CreateMap<Usuario, UsuarioView>();

                cfg.CreateMap<EmpresaView, Empresa>();
                cfg.CreateMap<Empresa, EmpresaView>();

                cfg.CreateMap<ProdutoView, Produto>();
                cfg.CreateMap<Produto, ProdutoView>();
            });
            config.AssertConfigurationIsValid();

            var mapper = new AutoMapper.Mapper(config, container.GetInstance);

            container.RegisterInstance<AutoMapper.IMapper>(mapper);
        }
    }
}
