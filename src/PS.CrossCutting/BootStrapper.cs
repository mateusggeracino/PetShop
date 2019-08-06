using Microsoft.Extensions.DependencyInjection;
using PS.Business;
using PS.Business.Interfaces;
using PS.Repository.Interfaces;
using PS.Repository.Repository;
using PS.Services.AutoMapper;
using PS.Services.Interfaces;
using PS.Services.Services;

namespace PS.CrossCutting
{
    public static class BootStrapper
    {
        public static void DependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IPetShopRepository, PetShopRepository>();
            services.AddTransient<IPetShopBusiness, PetShopBusiness>();
            services.AddTransient<IPetShopServices, PetShopServices>();

            var mapper = AutoMapperConfig.Register();
            services.AddSingleton(mapper.CreateMapper());
            services.BuildServiceProvider();
        }
    }
}
