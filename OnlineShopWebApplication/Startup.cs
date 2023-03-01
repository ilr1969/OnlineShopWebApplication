using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OnlineShop.Database;
using OnlineShopWebApplication.Helpers;
using Serilog;

namespace OnlineShopWebApplication
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
            string connection = Configuration.GetConnectionString("OnlineShop");
            services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(connection));
            services.AddSingleton<ToViewModelConverter>();
            services.AddSingleton<ToModelConverter>();
            services.AddControllersWithViews();
            services.AddTransient<IProductStorage, ProductDbStorage>();
            services.AddTransient<ICompareStorage, CompareDbStorage>();
            services.AddSingleton<IUserStorage, UserInMemoryStorage>();
            services.AddTransient<ICartStorage, CartDbStorage>();
            services.AddTransient<IMemoryProvider, MemoryProvider>();
            services.AddSingleton<IOrderStorage, OrderInMemoryStorage>();
            services.AddTransient<IFavoriteStorage, FavoriteDbStorage>();
            services.AddSingleton<IUserRoleStorage, UserRoleInMemoryStorage>();

            services.Configure<RequestLocalizationOptions>(option => { 
                var supportedCultures = new[] { 
                    new CultureInfo("en-US"), 
                };
                option.SupportedCultures = supportedCultures;
                option.SupportedUICultures = supportedCultures;
            });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();

            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "My",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
