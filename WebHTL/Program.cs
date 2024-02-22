using Repository.ApplicationDbContext;
using Repository.Repositories;
using Repository.Repositories.IRepositories;
using Repository.Services;
using Repository.Services.IServices;

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
            builder.Services.AddRazorPages(options => options.Conventions.AddPageRoute("/HomePage", ""));
            builder.Services.AddScoped<IRoadmapService, RoadmapService>();
            builder.Services.AddScoped<IRoadmapRepository, RoadmapRepository>();
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