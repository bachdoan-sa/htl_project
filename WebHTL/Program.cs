using Repository.ApplicationDbContext;
using Repository.Repositories;
using Repository.Repositories.IRepositories;
using Repository.Services;
using Repository.Services.IServices;
using WebHTL.Extensions;

namespace WebHTL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddSession();
            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddAutoMapperServices();

            builder.Services.AddRazorPages(options => options.Conventions.AddPageRoute("/HomePage", "")); 
                      
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<ICareerRepository, CareerRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseLessonRepository, CourseLessonRepository>();
            builder.Services.AddScoped<ICourseModuleRepository, CourseModuleRepository>();
            builder.Services.AddScoped<ICheckpointRepository, CheckpointRepository>();
            builder.Services.AddScoped<IDriverRepository, DriverRepository>();
            builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IRoadmapRepository, RoadmapRepository>();
            builder.Services.AddScoped<ISectionRepository, SectionRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();


            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ICareerService, CareerService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ICourseLessonService, CourseLessonService>();
            builder.Services.AddScoped<ICourseModuleService, CourseModuleService>();
            builder.Services.AddScoped<ICheckpointService, CheckpointService>();
            builder.Services.AddScoped<IDriverService, DriverService>();
            builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IRoadmapService, RoadmapService>();
            builder.Services.AddScoped<ISectionService, SectionService>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}