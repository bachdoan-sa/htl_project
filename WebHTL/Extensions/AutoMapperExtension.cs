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
                cfg.AddProfile(new CareerProfile());
                cfg.AddProfile(new CourseLessonProfile());
                cfg.AddProfile(new CourseProfile());
                cfg.AddProfile(new CourseModuleProfile());
                cfg.AddProfile(new CheckpointProfile());
                cfg.AddProfile(new DriverProfile());
                cfg.AddProfile(new OrderDetailProfile());
                cfg.AddProfile(new OrderProfile());
                cfg.AddProfile(new RoadmapProfile());
                cfg.AddProfile(new SectionProfile());
                cfg.AddProfile(new TransactionProfile());
            });

            return services;
        }
    }
}
