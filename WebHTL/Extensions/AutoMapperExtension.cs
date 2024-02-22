using AutoMapper;
using Repository;
using Repository.Mapper;

namespace WebHTL.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new AccountProfile());

            });

            return services;
        }
    }
}
