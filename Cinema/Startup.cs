using Cinema.DAL.EfDbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cinema
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
           /* var server = Configuration["DBServer"] ?? "ms-sql-server";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "A4s5dkw52+B!";
            var database = Configuration["Database"] ?? "WeatherDB";
            services.AddDbContext<CinemaDbContext>(
                options => options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID ={user};Password={password}"));
          */
            services.AddDbContext<DAL.EfDbContext.CinemaDbContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FilmVilag;Trusted_Connection=True;"));
            services.AddScoped<DAL.IFilmRepository, DAL.FilmRepository>();
            services.AddScoped<DAL.IOrderRepository, DAL.OrderRepository>();
            services.AddScoped<DAL.IProjectionRepository, DAL.ProjectionRepository>();
            services.AddScoped<DAL.IRoomRepository, DAL.RoomRepository>();
            services.AddScoped<DAL.ISeatRepository, DAL.SeatRepository>();
            services.AddScoped<DAL.IViewerRepository, DAL.ViewerRepository>();
            services.AddScoped<DAL.ISeatReservationRepository, DAL.SeatReservationRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            /*using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<CinemaDbContext>())
                {
                    System.Console.WriteLine("Migrálás");
                    context.Database.Migrate();
                 
                }
            }*/

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
