using Microsoft.Extensions.DependencyInjection;
using MyFood.Framework.Contracts.AppStart;
using MyFood.Framework.Contracts.DAO;
using MyFood.Framework.DAO;
using SimpleInjector;

namespace MyFood.Framework.AppStart
{
    public static class SimpleInjectorInit
    {
        public static void Initialize(Container container, IServiceCollection services)
        {
            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation();
            });

            InitializeContainer(container);
            ConfigAutoMapper(container);
        }

        private static void InitializeContainer(Container container)
        {
            container.Register(typeof(IRepository<>), typeof(BaseRepository<>), Lifestyle.Scoped);

            var resolver = new DependencyInjectionFacade(container);
            container.RegisterInstance<IDependencyInjectionFacade>(resolver);
        }

        private static void ConfigAutoMapper(Container container)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                // Map types here
            });
            config.AssertConfigurationIsValid();

            var mapper = new AutoMapper.Mapper(config, container.GetInstance);

            container.RegisterInstance<AutoMapper.IMapper>(mapper);
        }
    }
}
